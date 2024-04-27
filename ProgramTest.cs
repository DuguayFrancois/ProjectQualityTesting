using NUnit.Framework;
using Moq;
using Project;

[TestFixture]
public class InsuranceServiceTests
{
    [Test]
    public void RuralAgeLessThan18_ReturnsZero()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(17, "rural");

        // Assert
        Assert.That(premium, Is.EqualTo(0.00));
    }

    [Test]
    public void RuralAgeBetween18And30_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(25, "rural");

        // Assert
        Assert.That(premium, Is.EqualTo(5.00));
    }

    [Test]
    public void RuralAgeGreaterThan30_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(35, "rural");

        // Assert
        Assert.That(premium, Is.EqualTo(2.50));
    }

    [Test]
    public void UrbanAgeLessThan18_ReturnsZero()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(17, "urban");

        // Assert
        Assert.That(premium, Is.EqualTo(0.0));
    }

    [Test]
    public void UrbanAgeBetween18And30_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(19, "urban");

        // Assert
        Assert.That(premium, Is.EqualTo(6.0));
    }

    [Test]
    public void UrbanAgeGreaterThan30_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(42, "urban");

        // Assert
        Assert.That(premium, Is.EqualTo(5.0));
    }

    [Test]
    public void UnknownLocation_ReturnsZero()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(24, "Moon");

        // Assert
        Assert.That(premium, Is.EqualTo(0.0));
    }

    [Test]
    public void RuralAgeGreaterThan50_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(69, "rural");

        // Assert
        Assert.That(premium, Is.EqualTo(2.5));
    }

    [Test]
    public void UrbanAgeGreaterThan50_ReturnsCorrect()
    {
        // Arrange
        var mockDiscountService = new Mock<DiscountService>();
        mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(1.0); // Assuming no discount

        var insuranceService = new InsuranceService(mockDiscountService.Object);

        // Act
        var premium = insuranceService.CalcPremium(47, "urban");

        // Assert
        Assert.That(premium, Is.EqualTo(5.0));
    }

}
