using CobliIntegration.Domain.Cobli;
using CobliIntegration.Services.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobliIntegration.Services.Interfaces
{
    public interface ICobliService
    {
        ResponseEvent GetEvents(GetEventsFilter filter);
        MediaResponse GetMedias(GetMediaFilter filter);
        MediaLinkResponse GetMedia(string mediaId);
    }
}
