﻿using System.Collections.Generic;

namespace DataAccess.FormObject
{
    public class ResidenceFormObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BuildingID { get; set; }
        public IEnumerable<CommentFormObject> ResidenceComments { get; set; }

        public ResidenceFormObject()
        {
            ResidenceComments = new List<CommentFormObject>();
        }
    }
}