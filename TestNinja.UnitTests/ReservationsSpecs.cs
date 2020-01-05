using System;
using System.Text;
using System.Collections.Generic;
using Machine.Specifications;
using TestNinja.Fundamentals;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers

namespace TestNinja.UnitTests
{
    public class ReservationsSpecs
    {
        [Subject(typeof(Reservation))]
        public class When_cancelling_reservation
        {
            static Reservation subject;
            static User user = new User();

            Establish context = () =>
                subject = new Reservation {MadeBy = user};

            It should_be_doable_for_admin = () =>
                subject.CanBeCancelledBy(new User{IsAdmin = true}).ShouldBeTrue();

            It should_be_doable_for_creator = () =>
                subject.CanBeCancelledBy(user).ShouldBeTrue();

            It should_not_be_doable_for_other_user = () =>
                subject.CanBeCancelledBy(new User()).ShouldBeFalse();

        }

    }

}
