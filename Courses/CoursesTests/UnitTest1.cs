namespace CoursesTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Код, который пишет в консоль
            Console.WriteLine("Hello, World!");
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Hello, World!", result);
        }

        [Fact]
        public void Test2()
        {

            Assert.Equal(1, 1);
        }
    }
}