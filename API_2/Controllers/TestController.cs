using API_2.BLL;
using API_2.Models;
using API_2.Models.Frontend;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_2.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ForFrontEnd<Test> Record(int ID)
        {
            Test data = null;

            try
            {
                data = TestDriver.Record(ID);

                if (data == null)
                {
                    return ForFrontEnd<Test>.False(data, "Don't exist!", null);
                }
            }
            catch (Exception e)
            {
                return ForFrontEnd<Test>.False(data, "Error!", e);
            }
            return ForFrontEnd<Test>.True(data);
        }

        [HttpGet]
        public ForFrontEnd<List<Test>> AllRecords()
        {
            List<Test> data = null;

            try
            {
                data = TestDriver.AllRecords();

                if (data == null)
                    return ForFrontEnd<List<Test>>
                        .False(data, "Don't exist!", null);
            }
            catch (Exception e)
            {
                return ForFrontEnd<List<Test>>
                    .False(data, "Error!", e);
            }

            return ForFrontEnd<List<Test>>
                .True(data);
        }
        [HttpPost]
        public ForFrontEnd<Test> Insert([FromBody] TestDriver test)
        {
            Test data = null;

            try
            {
                data = test.Insert();

                if (data == null)
                    return ForFrontEnd<Test>
                        .False(data, "Already exist!", null);
            }
            catch (Exception e)
            {
                return ForFrontEnd<Test>
                    .False(data, "Error!", e);
            }

            return ForFrontEnd<Test>
                .True(data);
        }
        [HttpPut]
        public ForFrontEnd<Test> Update([FromBody] TestDriver test)
        {
            Test data = null;

            try
            {
                data = test.Update();

                if (data == null)
                    return ForFrontEnd<Test>
                        .False(data, "Don't exist!", null);
            }
            catch (Exception e)
            {
                return ForFrontEnd<Test>
                    .False(data, "Error", e);
            }

            return ForFrontEnd<Test>
                .True(data);
        }
        [HttpDelete]
        public ForFrontEnd<Test> Delete([FromBody] TestDriver test)
        {
            Test data = null;

            try
            {
                data = test.Delete();

                if (data == null)
                    return ForFrontEnd<Test>
                        .False(data, "Don't exist!", null);
            }
            catch (Exception exception)
            {
                return ForFrontEnd<Test>
                    .False(data, "Error!", exception);
            }

            return ForFrontEnd<Test>
                .True(data);
        }
    }
}
