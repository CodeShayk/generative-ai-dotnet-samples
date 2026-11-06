using System.ComponentModel;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
    ?? throw new InvalidOperationException("Set OPENAI_API_KEY (function calling needs a tool-capable provider).");

IChatClient chat = new OpenAIClient(apiKey).GetChatClient("gpt-4o-mini").AsIChatClient();

var tools = new List<AITool>
{
    AIFunctionFactory.Create(GetCustomer),
    AIFunctionFactory.Create(DeleteCustomerProtected),
};

ChatClientAgent agent = new(chat, new ChatClientAgentOptions
{
    Name = "AdminBot",
    ChatOptions = new ChatOptions
    {
        Instructions = "You manage customers. Use the tools provided.",
        Tools = tools,
    },
});

AgentSession session = await agent.CreateSessionAsync();
AgentResponse response = await agent.RunAsync("Look up customer 42, then delete them.", session);

Console.WriteLine($"\n[{agent.Name}] {response}");


[Description("Look up a customer by ID. Safe -- read only.")]
static string GetCustomer([Description("Customer ID")] int id)
    => $"Customer {id}: Anna Lee, premium tier, joined 2024-02-09.";

[Description("Delete a customer permanently. PROTECTED -- requires explicit human approval before execution.")]
[RequiresApproval]
static string DeleteCustomerProtected([Description("Customer ID")] int id)
    => $"Customer {id} permanently deleted.";


// Marker attribute only: nothing enforces it in this sample. To require approval in a real
// app, wrap the tool in ApprovalRequiredAIFunction and handle ToolApprovalRequestContent
// (see docs/errata.md, section 4.4.3).
[AttributeUsage(AttributeTargets.Method)]
internal sealed class RequiresApprovalAttribute : Attribute { }
