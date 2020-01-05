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
        public class When_cancelling_reservation_by_admin
        {
            static Reservation subject;
            static bool can_cancel;

            Establish context = () =>
                subject = new Reservation();

            Because of = () =>
                can_cancel = subject.CanBeCancelledBy(new User {IsAdmin = true});

            It should_be_possible = () =>
                can_cancel.ShouldBeTrue();

        }

        [Subject(typeof(Reservation))]
        public class When_canceling_reservation_by_creator
        {
            static Reservation subject;
            static bool can_cancel;
            static User user = new User();

            Establish context = () =>
                subject = new Reservation {MadeBy = user};

            Because of = () =>
                can_cancel = subject.CanBeCancelledBy(user);

            It should_be_possible = () =>
                can_cancel.ShouldBeTrue();
        }

        [Subject(typeof(Reservation))]
        public class when_cancelling_reservation_by_different_user
        {
            static Reservation subject;
            static bool can_cancel;

            Establish context = () =>
                subject = new Reservation {MadeBy = new User()};

            Because of = () => can_cancel = subject.CanBeCancelledBy(new User());

            It should_not_be_possible = () => 
                can_cancel.ShouldBeFalse();
        }

}

}
