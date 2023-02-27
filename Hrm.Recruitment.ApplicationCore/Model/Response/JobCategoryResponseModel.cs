﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.Recruitment.ApplicationCore.Model.Request
{
	public class JobCategoryResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }
    }
}

