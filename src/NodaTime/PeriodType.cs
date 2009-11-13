﻿#region Copyright and license information
// Copyright 2001-2009 Stephen Colebourne
// Copyright 2009 Jon Skeet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;

namespace NodaTime
{
    /// <summary>
    /// Original name: PeriodType
    /// </summary>
    /// <remarks>
    /// Defined values are:
    /// 
    /// Standard - years, months, weeks, days, hours, minutes, seconds, millis
    /// YearMonthDayTime - years, months, days, hours, minutes, seconds, millis
    /// YearMonthDay - years, months, days
    /// YearWeekDayTime - years, weeks, days, hours, minutes, seconds, millis
    /// YearWeekDay - years, weeks, days
    /// YearDayTime - years, days, hours, minutes, seconds, millis
    /// YearDay - years, days, hours
    /// DayTime - days, hours, minutes, seconds, millis
    /// Time - hours, minutes, seconds, millis
    /// plus one for each single type
    /// </remarks>
    [Flags]
    public enum PeriodType
    {
        Years = DurationFieldType.Years,
        Months = DurationFieldType.Months,
        Weeks = DurationFieldType.Weeks,
        Days = DurationFieldType.Days,
        Hours = DurationFieldType.Hours,
        Minutes = DurationFieldType.Minutes,
        Seconds = DurationFieldType.Seconds,
        Milliseconds = DurationFieldType.Milliseconds,

        Standard = Years | Months | Weeks | Days | Hours | Minutes | Seconds | Milliseconds,
        YearMonthDayTime = Years | Months | Days | Hours | Minutes | Seconds | Milliseconds,
        YearMonthDay = Years | Months | Days,
        YearWeekDayTime = Years | Weeks | Days | Hours | Minutes | Seconds | Milliseconds,
        YearWeekDay = Years | Weeks | Days,
        YearDayTime = Years | Days | Hours | Minutes | Seconds | Milliseconds,
        YearDay = Years | Days | Hours,
        DayTime = Days | Hours | Minutes | Seconds | Milliseconds,
        Time = Hours | Minutes | Seconds | Milliseconds,
    }
}
