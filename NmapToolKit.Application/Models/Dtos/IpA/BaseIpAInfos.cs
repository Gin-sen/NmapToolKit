using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Models.Dtos.IpA
{
  public record BaseIpAInfos(
        [property: JsonPropertyName("ifindex")] int Ifindex,
        [property: JsonPropertyName("ifname")] string Ifname,
        [property: JsonPropertyName("flags")] IReadOnlyList<string> Flags,
        [property: JsonPropertyName("mtu")] int Mtu,
        [property: JsonPropertyName("qdisc")] string Qdisc,
        [property: JsonPropertyName("operstate")] string Operstate,
        [property: JsonPropertyName("group")] string Group,
        [property: JsonPropertyName("txqlen")] int Txqlen,
        [property: JsonPropertyName("link_type")] string LinkType,
        [property: JsonPropertyName("address")] string Address,
        [property: JsonPropertyName("broadcast")] string Broadcast,
        [property: JsonPropertyName("addr_info")] IReadOnlyList<AddrInfo> AddrInfo,
        [property: JsonPropertyName("link")] object Link,
        [property: JsonPropertyName("link_index")] int? LinkIndex,
        [property: JsonPropertyName("link_netnsid")] int? LinkNetnsid
    );
  public record AddrInfo(
        [property: JsonPropertyName("family")] string Family,
        [property: JsonPropertyName("local")] string Local,
        [property: JsonPropertyName("prefixlen")] int Prefixlen,
        [property: JsonPropertyName("scope")] string Scope,
        [property: JsonPropertyName("label")] string Label,
        [property: JsonPropertyName("valid_life_time")] object ValidLifeTime,
        [property: JsonPropertyName("preferred_life_time")] object PreferredLifeTime,
        [property: JsonPropertyName("broadcast")] string Broadcast
    );
}
