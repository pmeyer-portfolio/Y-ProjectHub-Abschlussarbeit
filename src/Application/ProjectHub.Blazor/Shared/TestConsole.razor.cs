namespace ProjectHub.Blazor.Shared;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

public partial class TestConsole
{
    private readonly IList<Message> messages = new List<Message>();
    private readonly IJSRuntime? runtime;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            IJSRuntime? jsRuntime = this.runtime;
            if (jsRuntime != null)
            {
                await jsRuntime.InvokeVoidAsync("eval",
                    "document.getElementById('event-console').scrollTop = document.getElementById('event-console').scrollHeight");
            }
        }
    }

    public void OnClearClick()
    {
        this.Clear();
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public void Clear()
    {
        this.messages.Clear();

        this.InvokeAsync(this.StateHasChanged);
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public void Log(string message)
    {
        this.messages.Add(new Message { Date = DateTime.Now, Text = message });

        this.InvokeAsync(this.StateHasChanged);
    }

    public void Log(object value)
    {
        this.Log(JsonSerializer.Serialize(value));
    }

    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? Attributes { get; set; }

    private class Message
    {
        public DateTime Date { get; set; }
        public string? Text { get; set; }
    }
}