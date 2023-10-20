using CSGizmoBox.LocalCache;

namespace CSGizmoBox.Test.LocalCache
{
    public class LCacheTest
    {
        [Fact]
        public void Get_Null()
        {
            //get null
            var val1 = LCache.Get("key1");
            Assert.Null(val1);

        }

        [Fact]
        public void Set_Get_NotNull()
        {
            //add / get
            LCache.Set("key1", "value_01");

            var val1 = LCache.Get("key1");
            Assert.Equal(val1, "value_01");

        }


        [Fact]
        public void Get_DefaultValue()
        {

            var k = "key2";
            var val2 = LCache.Get(k, defaultValue:"default_value", addIfNotFound:true);
            Assert.Equal(val2, "default_value");

            Assert.Equal(val2, LCache.Get(k));

        }




        [Fact]
        public void Set_Timeout_1sec()
        {

            var key = "key_04";
            var value = "value >> 1 second";

            LCache.Set(key, value, 1);

            var content = LCache.Get(key);
            Assert.Equal(value, content);
            

            Thread.Sleep(2000);


            content = LCache.Get(key);
            Assert.Null(content);

        }

    }
}