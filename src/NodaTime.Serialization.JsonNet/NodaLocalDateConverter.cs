﻿#region Copyright and license information
// Copyright 2001-2009 Stephen Colebourne
// Copyright 2009-2010 Jon Skeet
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
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace NodaTime.Serialization.JsonNet
{
    /// <summary>
    /// Converts an <see cref="LocalDate"/> to and from the ISO 8601 date format (e.g. 2008-04-12).
    /// </summary>
    public class NodaLocalDateConverter : NodaConverterBase<LocalDate>
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd";

        public NodaLocalDateConverter()
        {
            // default values
            DateFormat = DefaultDateTimeFormat;
            Culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Gets or sets the date format used when converting to and from JSON.
        /// </summary>
        /// <value>The date format used when converting to and from JSON.</value>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the culture used when converting to and from JSON.
        /// </summary>
        /// <value>The culture used when converting to and from JSON.</value>
        public CultureInfo Culture { get; set; }

        protected override LocalDate ReadJsonImpl(JsonReader reader, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new InvalidDataException(
                    string.Format("Unexpected token parsing instant. Expected String, got {0}.",
                    reader.TokenType));
            }
            string text = reader.Value.ToString();
            return string.IsNullOrEmpty(DateFormat)
                       ? LocalDate.Parse(text, Culture)
                       : LocalDate.ParseExact(text, DateFormat, Culture);
        }

        protected override void WriteJsonImpl(JsonWriter writer, LocalDate value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(DateFormat, Culture));
        }
    }
}
