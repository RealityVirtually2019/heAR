/**
* Copyright 2018 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using FullSerializer;

namespace  IBM.Watson.DeveloperCloud.Services.CompareComply.v1
{
    /// <summary>
    /// Basic information about the input document.
    /// </summary>
    [fsObject]
    public class Document
    {
        /// <summary>
        /// Document title, if detected.
        /// </summary>
        [fsProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// The input document converted into HTML format.
        /// </summary>
        [fsProperty("html")]
        public string Html { get; set; }
        /// <summary>
        /// The MD5 hash value of the input document.
        /// </summary>
        [fsProperty("hash")]
        public string Hash { get; set; }
        /// <summary>
        /// The label applied to the input document with the calling method's `file1_label` or `file2_label` value.
        /// </summary>
        [fsProperty("label")]
        public string Label { get; set; }
    }

}
