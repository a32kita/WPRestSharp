﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public class WPRestPost
    {
        public WPRestPostId? Id
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }

        public DateTime? DateGmt
        {
            get;
            set;
        }

        public WPRenderableText Guid
        {
            get;
            set;
        }

        public DateTime? Modified
        {
            get;
            set;
        }

        public DateTime? ModifiedGmt
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Slug
        {
            get;
            set;
        }

        public Uri Link
        {
            get;
            set;
        }

        public WPRenderableText Title
        {
            get;
            set;
        }

        public WPRenderableText Content
        {
            get;
            set;
        }

        public WPRestUserId? Author
        {
            get;
            set;
        }

        public WPRestCategoryId[] Categories
        {
            get;
            set;
        }
    }
}
