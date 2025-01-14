﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Vatsim.Vatis.Profiles.AtisFormat.Nodes.Converter;

namespace Vatsim.Vatis.Profiles.AtisFormat.Nodes;

public class Clouds : BaseFormat
{
    public Clouds()
    {
        Template = new()
        {
            Text = "{clouds}",
            Voice = "{clouds}"
        };
    }

    public bool IdentifyCeilingLayer { get; set; } = true;
    public bool ConvertToMetric { get; set; }

    [JsonConverter(typeof(CloudConverter))]
    public Dictionary<string, object> Types { get; set; } = new()
    {
        { "FEW", new CloudType("FEW{altitude}", "few clouds at {altitude}") },
        { "SCT", new CloudType("SCT{altitude}{convective}", "{altitude} scattered {convective}") },
        { "BKN", new CloudType("BKN{altitude}{convective}", "{altitude} broken {convective}") },
        { "OVC", new CloudType("OVC{altitude}{convective}", "{altitude} overcast {convective}") },
        { "VV", new CloudType("VV{altitude}", "indefinite ceiling {altitude}") },
        { "NSC", new CloudType("NSC", "no significant clouds") },
        { "NCD", new CloudType("NCD", "no clouds detected") },
        { "CLR", new CloudType("CLR", "sky clear below one-two thousand") },
        { "SKC", new CloudType("SKC", "sky clear") },
    };

    public Dictionary<string, string> ConvectiveTypes { get; set; } = new()
    {
        { "CB", "cumulonimbus" },
        { "TCU", "towering cumulus" }
    };
}

public class CloudType
{
    public string Text { get; set; }
    public string Voice { get; set; }
    public CloudType(string text, string voice)
    {
        Text = text;
        Voice = voice;
    }
}
