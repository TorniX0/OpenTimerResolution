using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTimerResolution
{
    public static class Utilities
    {
        #region Methods

        public static async Task DownloadAsync(Uri requestUri, string filename)
        {
            HttpClient client = new();

            using var s = await client.GetStreamAsync(requestUri);
            using var fs = new FileStream(filename, FileMode.Create);
            await s.CopyToAsync(fs);
        }

        #endregion
    }
}
