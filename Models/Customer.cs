namespace BackEndRemiMestdagh.Data.Models
{
    public class Customer
    {

        #region Properties
            //add extra properties if needed
            public int CustomerId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }


            #endregion

            #region Constructors
            public Customer()
            {
                
            }
            #endregion

            
            
        }
    }
