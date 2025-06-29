using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [SetUp] // Runs before each test to ensure isolation
        public void SetUp()
        {
            _mockMailSender = new Mock<IMailSender>();

            // Setup: Always return true for any input
            _mockMailSender
                .Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSentSuccessfully()
        {
            // Act
            var result = _customerComm.SendMailToCustomer("cust123@abc.com", "Some message");

            // Assert
            Assert.IsTrue(result);

            // Verify SendMail was called once
            _mockMailSender.Verify(sender => sender.SendMail("cust123@abc.com", "Some message"), Times.Once);
        }
    }
}
