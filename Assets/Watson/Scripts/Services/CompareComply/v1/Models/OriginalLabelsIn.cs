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
using FullSerializer.Internal;
using System;
using System.Collections.Generic;

namespace  IBM.Watson.DeveloperCloud.Services.CompareComply.v1
{
    /// <summary>
    /// The original labeling from the input document, without the submitted feedback.
    /// </summary>
    [fsObject(Converter = typeof(OriginalLabelsInConverter))]
    public class OriginalLabelsIn
    {
        /// <summary>
        /// Description of the action specified by the element and whom it affects.
        /// </summary>
        [fsProperty("types")]
        public List<TypeLabel> Types { get; set; }
        /// <summary>
        /// List of functional categories into which the element falls; in other words, the subject matter of the
        /// element.
        /// </summary>
        [fsProperty("categories")]
        public List<Category> Categories { get; set; }
    }

    #region OriginalLabelsIn Converter
    public class OriginalLabelsInConverter : fsConverter
    {
        private fsSerializer _serializer = new fsSerializer();

        public override bool CanProcess(Type type)
        {
            return type == typeof(OriginalLabelsIn);
        }

        public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
        {
            if (data.IsString == false)
            {
                return fsResult.Fail("Type converter requires a string");
            }
            instance = fsTypeCache.GetType(data.AsString);
            if (instance == null)
            {
                return fsResult.Fail("Unable to find type " + data.AsString);
            }
            return fsResult.Success;
        }

        public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
        {
            OriginalLabelsIn originalLabelsIn = (OriginalLabelsIn)instance;
            serialized = null;

            Dictionary<string, fsData> serialization = new Dictionary<string, fsData>();

            fsData tempData = null;
            
            if (originalLabelsIn.Types != null && originalLabelsIn.Types.Count > 0)
            {
                _serializer.TrySerialize(originalLabelsIn.Types, out tempData);
                serialization.Add("types", tempData);
            }

            if (originalLabelsIn.Categories != null && originalLabelsIn.Categories.Count > 0)
            {
                _serializer.TrySerialize(originalLabelsIn.Categories, out tempData);
                serialization.Add("categories", tempData);
            }

            serialized = new fsData(serialization);

            return fsResult.Success;
        }
    }
    #endregion
}
