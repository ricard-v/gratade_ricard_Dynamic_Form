﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class BinaryQuestion:QuestionBase
    {
        public BinaryQuestion(): base()
        {

        }

        internal override AnswerBase GetAnswerInstance(FormAnswer answerform)
        {
            return new BinaryAnswer();
        }

    }
}
