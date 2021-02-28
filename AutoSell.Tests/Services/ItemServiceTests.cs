using AutoSell.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutoSell.Tests.Services
{
    public class ItemServiceTests
    {
        private ModelServiceTests ModelServiceTests => new ModelServiceTests();

        [Fact]
        public void GetAll_ShouldReturnMoreThanZero()
        {
            ModelServiceTests.GetAll_ShouldReturnMoreThanZero<Item>();
        }

        [Fact]
        public void GetById_ShouldReturnMoreThanZero()
        {
            ModelServiceTests.GetById_ShouldReturnNotNull<Item>();
        }
    }
}
