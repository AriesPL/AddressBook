namespace AddressBook
{
    using System;

    public class People
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }

        public virtual string NickName { get; set; }
        public virtual string Address { get; set; }
        public virtual string ICQ { get; set; }
        public virtual string Skype { get; set; }
    }
}