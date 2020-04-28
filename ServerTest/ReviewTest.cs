using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Control;
using Service.Model;

namespace ServiceTest
{
    [TestClass]
    public class ReviewTest
    {
        
        [TestMethod]
        public void TestInsertReview()
        {
            //ARRANGE
            ReviewControl control = new ReviewControl();
            ServiceReview review = new ServiceReview();
            review.Comment = "Test Comment";
            review.Rating = 3;
            int testId = 0;
            
            //ACT
            testId = control.InsertReview(review);

            //ASSERT
            Assert.IsTrue(testId > 0);
        }
    }
}
