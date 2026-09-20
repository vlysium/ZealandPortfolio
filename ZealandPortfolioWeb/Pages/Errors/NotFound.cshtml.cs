using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandPortfolioWeb.Pages.Errors
{
    public class NotFoundModel : PageModel
    {
        /// <summary>
        /// Gets the original path that caused the 404 error, if available.
        /// </summary>
        public string? OriginalPath { get; private set; }

        public void OnGet()
        {
            IStatusCodeReExecuteFeature? feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            OriginalPath = feature?.OriginalPath;
        }
    }
}
