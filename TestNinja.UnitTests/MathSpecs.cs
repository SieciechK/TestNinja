using System;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    public class MathSpecs
    {
        [Subject(typeof(Math))]
        public class when_calling_add_function
        {
            static Math subject;

            Establish context = () => 
                subject = new Math();

            It should_return_sum_of_both_numbers = () =>
                subject.Add(1, 2).ShouldEqual(3);
        }

        [Subject(typeof(Math))]
        public class when_calling_max_function
        {
            static Math subject;

            Establish context = () =>
                subject = new Math();

            It should_return_first_argument_when_its_greater = () =>
                subject.Max(2, 1).ShouldEqual(2);

            It should_return_second_argument_when_its_greater = () =>
                subject.Max(1, 2).ShouldEqual(2);

            It should_return_same_argument_when_they_are_equal = () =>
                subject.Max(1, 1).ShouldEqual(1);

        }
    }
}
