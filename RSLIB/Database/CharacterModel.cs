using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class CharacterModel : DB
    {
        private string table = "characters";
        private string name;
        private byte job;
        private int level;
        private int game_operator;
        private int place_code;
        private int position_x;
        private int position_y;
        private string username;

        public CharacterModel(string name, byte job, int level, int game_operator, int place_code, int position_x, int position_y, string username)
        {
            this.name = name;
            this.job = job;
            this.level = level;
            this.game_operator = game_operator;
            this.place_code = place_code;
            this.position_x = position_x;
            this.position_y = position_y;
            this.username = username;
            this.SetTable(this.table);
        }

        public CharacterModel() {
            this.SetTable(this.table);
        }

        public bool NameInUse()
        {
            int count = Select($"name='{this.name}'").Count;
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public List<Dictionary<string, object>> SelectCharacter(string username) { 
            return Select($"username = '{username}'");
        }

        public void DeletePlayerByName(string name)
        {
            this.name = name;
            if (this.NameInUse())
            {
                List<Dictionary<string, object>> character =  Select($"name = '{name}'");
                int id = (int)character[0]["id"];
                Delete(id);
            }
        }

        public void SavePlayer()
        {
            Dictionary<string, object> character = new Dictionary<string, object>();
            character["name"] = name;
            character["job"] = job;
            character["level"] = level;
            character["operator"] = game_operator;
            character["place_code"] = place_code;
            character["position_x"] = position_x;
            character["position_y"] = position_y;
            character["username"] = username;
            Insert(character);
        }
    }
}
