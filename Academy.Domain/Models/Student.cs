﻿using System;
using System.Collections.Generic;

namespace Academy.Domain.Models;

public partial class Student
{
    public long Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long Age { get; set; }

    public string Career { get; set; } = null!;
}
