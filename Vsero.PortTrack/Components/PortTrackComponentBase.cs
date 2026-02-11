using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Vsero.PortTrack.Components;

public abstract class PortTrackComponentBase : ComponentBase, IDisposable
{

    [Inject] protected IJSRuntime JSRuntime { get; set; } = null!;
    protected bool IsDisposed { get; private set; }
    protected CancellationTokenSource? _cts;
    private DotNetObjectReference<PortTrackComponentBase>? _objRef;



    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _objRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("listenVisibilityChange", _objRef);
        }
    }



    [JSInvokable]
    public async Task OnVisibilityChanged()
    {
        if (IsDisposed) return;
        await OnPageBecameVisibleAsync();
    }



    protected virtual Task OnPageBecameVisibleAsync() 
        => Task.CompletedTask;



    protected CancellationToken CancellationToken(int seconds = 10)
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = new CancellationTokenSource(TimeSpan.FromSeconds(seconds));
        return _cts.Token;
    }



    public void Dispose()
    {
        Dispose(true);
        IsDisposed = true;
        GC.SuppressFinalize(this);
    }



    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }

}
