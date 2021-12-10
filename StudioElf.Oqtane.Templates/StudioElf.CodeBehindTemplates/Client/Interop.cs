using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace StudioElf.CodeBehindTemplates
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
