﻿using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Application.Models.Core.Branches;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Feedbacks;

public class FeedbackDto: BaseDto, IMapFrom<Feedback>
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public FeedbackTypeDto FeedbackType { get; set; }
}