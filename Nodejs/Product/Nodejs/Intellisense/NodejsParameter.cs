﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using Microsoft.NodejsTools.Analysis;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;

namespace Microsoft.NodejsTools.Intellisense {
    internal class NodejsParameter : IParameter {
        private readonly ISignature _signature;
        private readonly ParameterResult _param;
        private readonly string _documentation;
        private readonly Span _locus, _ppLocus;

        public NodejsParameter(ISignature signature, ParameterResult param, Span locus, Span ppLocus, string documentation = null) {
            _signature = signature;
            _param = param;
            _locus = locus;
            _ppLocus = ppLocus;
            _documentation = (documentation ?? _param.Documentation).LimitLines(15, stopAtFirstBlankLine: true);
        }

        public string Documentation {
            get { return _documentation; }
        }

        public Span Locus {
            get { return _locus; }
        }

        public string Name {
            get { return _param.Name; }
        }

        public ISignature Signature {
            get { return _signature; }
        }

        public Span PrettyPrintedLocus {
            get { return _ppLocus; }
        }
    }
}
