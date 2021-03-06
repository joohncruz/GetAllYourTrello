﻿using System.Collections.Generic;

namespace GetAllYourTrello.DataTransferObjects.Board
{
    public class Board
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public bool closed { get; set; }
        public string idOrganization { get; set; }
        public bool pinned { get; set; }
        public string url { get; set; }
        public string shortUrl { get; set; }
        public Prefs prefs { get; set; }
        public List<Labelnames> labelNames { get; set; }
    }

    public class Prefs
    {
        public string permissionLevel { get; set; }
        public string voting { get; set; }
        public string comments { get; set; }
        public string invitations { get; set; }
        public bool selfJoin { get; set; }
        public bool cardCovers { get; set; }
        public string cardAging { get; set; }
        public bool calendarFeedEnabled { get; set; }
        public string background { get; set; }
        public string backgroundImage { get; set; }
        public List<Backgroundimagescaled> backgroundImageScaled { get; set; }
        public bool backgroundTile { get; set; }
        public string backgroundBrightness { get; set; }
        public bool canBePublic { get; set; }
        public bool canBeOrg { get; set; }
        public bool canBePrivate { get; set; }
        public bool canInvite { get; set; }
    }

    public class Backgroundimagescaled
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }

    public class Labelnames
    {
        public string green { get; set; }
        public string yellow { get; set; }
        public string orange { get; set; }
        public string red { get; set; }
        public string purple { get; set; }
        public string blue { get; set; }
        public string sky { get; set; }
        public string lime { get; set; }
        public string pink { get; set; }
        public string black { get; set; }
    }

}
