using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using static WinFormsApp1.battleHandler;
using CBPRM;
using static CBPRM.actionLibrary;

namespace WinFormsApp1
{
    public class dataHandler
    {
        public List<battleHandler.characterSlot> generateFriendlyList()
        {
            List<battleHandler.characterSlot> characterList = new List<battleHandler.characterSlot>();

            int slotID = 1; // Initialize slotID

            foreach (characterData existingChar in persistantData.characterList)
            {
                battleHandler.characterSlot newCharacter = new battleHandler.characterSlot
                {
                    cid = existingChar.charUID, // Assuming charUID exists in characterData
                    slotID = slotID, // Assign slotID
                    speed = existingChar.charSpeed, // charSpeed
                    alive = true, // Initialize as alive
                    _charData = existingChar // Directly assign the existing characterData
                };

                // Load actions and other initializations here
                newCharacter._charData.loadActions();
                newCharacter._charData.AvailableActions.Add(persistantData.actionLibrary.MeleeAttackAction);
                if (newCharacter._charData.charBackgroundBonus == 4)
                {
                    newCharacter._charData.AvailableActions.Add(persistantData.actionLibrary.SpellAttackAction);
                }

                characterList.Add(newCharacter);
                slotID++; // Increment slotID for the next character
            }

            return characterList;
        }

        public List<npcSlot> GenerateNpcSlotList(List<npcData> npcDataList)
        {
            List<npcSlot> npcSlotList = new List<npcSlot>();

            int slotID = 1; // Initialize slotID
            foreach (var npc in npcDataList)
            {
                npcSlot newNpcSlot = new npcSlot
                {
                    cid = npc.spawnID, // NPC ID
                    slotID = slotID, // Assign slotID
                    speed = npc.npcSpeed, // NPC speed
                    alive = true, // Initialize as alive
                    _npcData = npc // Assign the npcData
                };

                npcSlotList.Add(newNpcSlot);
                slotID++; // Increment slotID for the next NPC
            }

            return npcSlotList;
        }
        public List<npcData> GenerateNPCList(List<characterData> playerCharacters, int zoneID)
        {
            random = new Random();
            string connectionString = "Server=localhost;Database=world;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            List<npcData> npcList = new List<npcData>();

            // Calculate the total maxEXP of the player's party
            int totalPartyMaxEXP = 0;
            foreach (var character in playerCharacters)
            {
                totalPartyMaxEXP += character.charMaxEXP;
            }

            // Calculate the upper limit for NPC EXP
            int upperLimitEXP = (int)(totalPartyMaxEXP * 1.25);

            try
            {
                connection.Open();

                // Fetch NPCs based on the calculated EXP and zoneID
                string fetchNPCsQuery = "SELECT * FROM npcs WHERE npcEXPValue <= @upperLimitEXP AND zoneID = @zoneID";
                MySqlCommand fetchNPCsCmd = new MySqlCommand(fetchNPCsQuery, connection);
                fetchNPCsCmd.Parameters.AddWithValue("@upperLimitEXP", upperLimitEXP);
                fetchNPCsCmd.Parameters.AddWithValue("@zoneID", zoneID);

                MySqlDataReader reader = fetchNPCsCmd.ExecuteReader();

                List<npcData> availableNPCs = new List<npcData>();
                while (reader.Read())
                {
                    npcData npc = new npcData
                    {

                        spawnID = GenerateRandomNumber(),
                       
                        npcName = reader.GetString("npcName"),
                        npcMaxHP = reader.GetInt32("npcHP"),
                        npcCurrentHP = reader.GetInt32("npcHP"),
                        npcMaxMana = reader.GetInt32("npcMana"),
                        npcCurrentMana = reader.GetInt32("npcMana"),
                        npcCurrentEnergy = reader.GetInt32("npcEnergy"),
                        npcMaxEnergy = reader.GetInt32("npcEnergy"),
                        npcStrength = reader.GetInt32("npcSTR"),
                        npcDex = reader.GetInt32("npcDEX"),
                        npcIntelligence = reader.GetInt32("npcINT"),
                        npcSpeed = reader.GetInt32("npcSpeed"),
                        npcFocus = reader.GetInt32("npcFocus"),
                        npcEXPValue = reader.GetInt32("npcEXPValue"),
                        npcSkill1 = reader.GetInt32("npcSkill1"),
                        npcSkill2 = reader.GetInt32("npcSkill2"),
                        npcSkill3 = reader.GetInt32("npcSkill3"),
                        TimeUntilNextAction = 2500 - (reader.GetInt32("npcSpeed") * reader.GetInt32("npcFocus")),
                        maxOnScreen = reader.GetInt32("maxOnScreen")
                    };
                    npc.npcID = npc.spawnID;
                    Debug.WriteLine("Added spawn ID: " + npc.spawnID);
                    npc.loadActions();
                    npc.AvailableActions.Add(persistantData.actionLibrary.MeleeAttackAction);
                    availableNPCs.Add(npc);
                }

                // Randomly select NPCs to add to the list
                Random rand = new Random();
                int totalNPCExp = 0;
                while (totalNPCExp < totalPartyMaxEXP && npcList.Count < 10)
                {
                    int index = rand.Next(availableNPCs.Count);
                    npcData selectedNPC = availableNPCs[index];

                    if (totalNPCExp + selectedNPC.npcEXPValue <= upperLimitEXP)
                    {
                        npcList.Add(selectedNPC);
                        totalNPCExp += selectedNPC.npcEXPValue;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }

            return npcList;
        }
        public List<characterData> GetPlayerCharacters(int accuid)
        {

            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            List<characterData> playerCharacters = new List<characterData>();

            try
            {
                connection.Open();

                // Fetch the character data based on the accuid
                string fetchCharactersQuery = "SELECT * FROM characters WHERE accuid = @accuid";
                MySqlCommand fetchCharactersCmd = new MySqlCommand(fetchCharactersQuery, connection);
                fetchCharactersCmd.Parameters.AddWithValue("@accuid", accuid);

                MySqlDataReader reader = fetchCharactersCmd.ExecuteReader();

                while (reader.Read())
                {
                    characterData charData = new characterData
                    {
                    charUID = reader.GetInt32("charuid"),
                        charName = reader.GetString("charName"),
                        charMaxHP = reader.GetInt32("charMaxHP"),
                        charCurrentHP = reader.GetInt32("charCurrentHP"),
                        charMaxMana = reader.GetInt32("charMaxMana"),
                        charCurrentMana = reader.GetInt32("charCurrentMana"),
                        charMaxEnergy = reader.GetInt32("charMaxEnergy"),
                        charCurrentEnergy = reader.GetInt32("charCurrentEnergy"),
                        charStrength = reader.GetInt32("charStrength"),
                        charDex = reader.GetInt32("charDex"),
                        charIntelligence = reader.GetInt32("charIntelligence"),
                        charFocus = reader.GetInt32("charFocus"),
                        charSpeed = reader.GetInt32("charSpeed"),
                        charMaxEXP = reader.GetInt32("charMaxEXP"),
                        charCurrentEXP = reader.GetInt32("charCurrentEXP"),
                        charBackgroundBonus = reader.GetInt32("charBackgroundBonus"),
                        charSkill1 = reader.GetInt32("charSkill1"),
                        charSkill2 = reader.GetInt32("charSkill2"),
                        charSkill3 = reader.GetInt32("charSkill3"),
                        skillPoints = reader.GetInt32("skillpoints"),  // New field
                        statPoints = reader.GetInt32("statpoints")     // New field

                    };
                    playerCharacters.Add(charData);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }

            return playerCharacters;
        }
        public bool CreateCharacter(characterData newChar, int accuid, int backgroundID)
        {

            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Check if the character name is already taken
                string checkNameQuery = "SELECT COUNT(*) FROM characters WHERE charName = @charName";
                MySqlCommand checkNameCmd = new MySqlCommand(checkNameQuery, connection);
                checkNameCmd.Parameters.AddWithValue("@charName", newChar.charName);

                long count = (long)checkNameCmd.ExecuteScalar();

                if (count == 0)
                {
                    // Insert the new character into the database
                    string insertQuery = "INSERT INTO characters (accuid, charName, charMaxHP, charCurrentHP, charMaxMana, charCurrentMana, charMaxEnergy, charCurrentEnergy, charStrength, charDex, charIntelligence, charFocus, charSpeed, charMaxEXP, charCurrentEXP, charBackgroundBonus, skillpoints, statpoints) VALUES (@accuid, @charName, @charMaxHP, @charCurrentHP, @charMaxMana, @charCurrentMana, @charMaxEnergy, @charCurrentEnergy, @charStrength, @charDex, @charIntelligence, @charFocus, @charSpeed, @charMaxEXP, @charCurrentEXP, @charBackgroundBonus, @skillpoints, @statpoints)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

     switch (backgroundID)
                    {
                        case 0:
                            newChar.charDex += 2;
                            newChar.charStrength += 2;
                            newChar.charFocus += 2;
                            newChar.charSpeed += 2;
                            break;
                            case 1:
                            newChar.charMaxHP = (int)((double)newChar.charMaxHP * 1.10f);
                            newChar.charCurrentHP = newChar.charMaxHP;

                            newChar.charMaxMana = (int)((double)newChar.charMaxMana * 1.10f);
                            newChar.charCurrentMana = newChar.charMaxMana;


                            newChar.charMaxEnergy = (int)((double)newChar.charMaxEnergy * 1.10f);
                            newChar.charCurrentEnergy = newChar.charMaxEnergy;

                            break;
                            case 2:
                            newChar.charDex += 1;
                            newChar.charStrength += 1;
                            newChar.charIntelligence += 1;
                            break;

                            case 3:

                            newChar.charMaxHP = (int)((double)newChar.charMaxHP * 1.20f);
                            newChar.charCurrentHP = newChar.charMaxHP;
                            break;
                            case 4:

                            newChar.charMaxMana = (int)((double)newChar.charMaxMana * 1.20f);
                            newChar.charCurrentMana = newChar.charMaxMana;
                            break;
                        default:
                            break;
                    }

                    insertCmd.Parameters.AddWithValue("@accuid", accuid);
                    insertCmd.Parameters.AddWithValue("@charName", newChar.charName);
                    insertCmd.Parameters.AddWithValue("@charMaxHP", newChar.charMaxHP);
                    insertCmd.Parameters.AddWithValue("@charCurrentHP", newChar.charCurrentHP);
                    insertCmd.Parameters.AddWithValue("@charMaxMana", newChar.charMaxMana);
                    insertCmd.Parameters.AddWithValue("@charCurrentMana", newChar.charCurrentMana);
                    insertCmd.Parameters.AddWithValue("@charMaxEnergy", newChar.charMaxEnergy);
                    insertCmd.Parameters.AddWithValue("@charCurrentEnergy", newChar.charCurrentEnergy);
                    insertCmd.Parameters.AddWithValue("@charStrength", newChar.charStrength);
                    insertCmd.Parameters.AddWithValue("@charDex", newChar.charDex);
                    insertCmd.Parameters.AddWithValue("@charIntelligence", newChar.charIntelligence);
                    insertCmd.Parameters.AddWithValue("@charFocus", newChar.charFocus);
                    insertCmd.Parameters.AddWithValue("@charSpeed", newChar.charSpeed);
                    insertCmd.Parameters.AddWithValue("@charMaxEXP", newChar.charMaxEXP);
                    insertCmd.Parameters.AddWithValue("@charCurrentEXP", newChar.charCurrentEXP);
                    insertCmd.Parameters.AddWithValue("@charBackgroundBonus", newChar.charBackgroundBonus);
                    insertCmd.Parameters.AddWithValue("@skillpoints", newChar.skillPoints);  // New field
                    insertCmd.Parameters.AddWithValue("@statpoints", newChar.statPoints);    // New field


                    insertCmd.ExecuteNonQuery();
                    return true;  // Character successfully created
                }
                else
                {
                    return false;  // Character name already taken
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<characterData> LoadPlayerCharacters(int accountId)
        {
            List<characterData> characterList = new List<characterData>();
            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT * FROM characters WHERE accuid = @accountId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@accountId", accountId);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    characterData character = new characterData
                    {
                        charName = reader.GetString("charName"),
                        charUID = reader.GetInt32("charuid"),
                        charMaxHP = reader.GetInt32("charMaxHP"),
                        charCurrentHP = reader.GetInt32("charCurrentHP"),
                        charMaxMana = reader.GetInt32("charMaxMana"),
                        charCurrentMana = reader.GetInt32("charCurrentMana"),
                        charMaxEnergy = reader.GetInt32("charMaxEnergy"),
                        charCurrentEnergy = reader.GetInt32("charCurrentEnergy"),
                        charStrength = reader.GetInt32("charStrength"),
                        charDex = reader.GetInt32("charDex"),
                        charIntelligence = reader.GetInt32("charIntelligence"),
                        charSpeed = reader.GetInt32("charSpeed"),
                        charFocus = reader.GetInt32("charFocus"),
                        charMaxEXP = reader.GetInt32("charMaxEXP"),
                        charCurrentEXP = reader.GetInt32("charCurrentEXP"),
                        charSkill1 = reader.GetInt32("charSkill1"),
                        charSkill2 = reader.GetInt32("charSkill2"),
                        charSkill3 = reader.GetInt32("charSkill3"),
                        skillPoints = reader.GetInt32("skillPoints"),
                        statPoints = reader.GetInt32("statPoints")
                        // Add other fields as needed
                    };
                    characterList.Add(character);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }

            return characterList;
        }
        public void PopulateCharacterList(int accuid, ListBox listBox)
        {

            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Fetch the character names based on the accuid
                string fetchNamesQuery = "SELECT charName FROM characters WHERE accuid = @accuid";
                MySqlCommand fetchNamesCmd = new MySqlCommand(fetchNamesQuery, connection);
                fetchNamesCmd.Parameters.AddWithValue("@accuid", accuid);

                MySqlDataReader reader = fetchNamesCmd.ExecuteReader();

                List<string> characterNames = new List<string>();
                while (reader.Read())
                {
                    characterNames.Add(reader.GetString("charName"));
                }

                // Populate the ListBox
                listBox.Items.Clear();
                foreach (string name in characterNames)
                {
                    listBox.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }
        }
        private Random random;

        public int GenerateRandomNumber()
        {
            return random.Next(1, 1001);
        }
    

        public bool RegisterChatUser(string nickName, int UID)
        {

            string connectionString = "Server=localhost;Database=chat;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Check if the username (nickName) is already taken
                string checkNameQuery = "SELECT COUNT(*) FROM chatusers WHERE nickName = @nickName";
                MySqlCommand checkNameCmd = new MySqlCommand(checkNameQuery, connection);
                checkNameCmd.Parameters.AddWithValue("@nickName", nickName);
                checkNameCmd.Parameters.AddWithValue("@UID", UID);

                long count = (long)checkNameCmd.ExecuteScalar();

                if (count == 0)
                {
                    // Insert the new user into the database
                    string insertQuery = "INSERT INTO chatusers (UID, nickName, onlineStatus, lastOnline) VALUES (@UID, @nickName, '1', NOW())";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@nickName", nickName);
                    insertCmd.Parameters.AddWithValue("@UID", UID);

                    insertCmd.ExecuteNonQuery();
                    persistantData.chatNickname = nickName;
                    persistantData.chatEnabled = true;
                    return true;  // User successfully registered
                }
                else
                {
                    return false;  // Username already taken
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public void SaveCharacter(characterData character)
        {

            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE characters SET charMaxHP = @charMaxHP, charCurrentHP = @charCurrentHP, charMaxMana = @charMaxMana, " +
                             "charCurrentMana = @charCurrentMana, charMaxEnergy = @charMaxEnergy, charCurrentEnergy = @charCurrentEnergy, " +
                             "charStrength = @charStrength, charDex = @charDex, charIntelligence = @charIntelligence, charFocus = @charFocus, " +
                             "charSpeed = @charSpeed, charMaxEXP = @charMaxEXP, charCurrentEXP = @charCurrentEXP, charBackgroundBonus = @charBackgroundBonus, " +
                             "charSkill1 = @charSkill1, charSkill2 = @charSkill2, charSkill3 = @charSkill3, skillPoints = @skillPoints, statPoints = @statPoints " +
                             "WHERE charUID = @charUID;";
                try
                {

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@charMaxHP", character.charMaxHP);
                        cmd.Parameters.AddWithValue("@charCurrentHP", character.charCurrentHP);
                        cmd.Parameters.AddWithValue("@charMaxMana", character.charMaxMana);
                        cmd.Parameters.AddWithValue("@charCurrentMana", character.charCurrentMana);
                        cmd.Parameters.AddWithValue("@charMaxEnergy", character.charMaxEnergy);
                        cmd.Parameters.AddWithValue("@charCurrentEnergy", character.charCurrentEnergy);
                        cmd.Parameters.AddWithValue("@charStrength", character.charStrength);
                        cmd.Parameters.AddWithValue("@charDex", character.charDex);
                        cmd.Parameters.AddWithValue("@charIntelligence", character.charIntelligence);
                        cmd.Parameters.AddWithValue("@charFocus", character.charFocus);
                        cmd.Parameters.AddWithValue("@charSpeed", character.charSpeed);
                        cmd.Parameters.AddWithValue("@charMaxEXP", character.charMaxEXP);
                        cmd.Parameters.AddWithValue("@charCurrentEXP", character.charCurrentEXP);
                        cmd.Parameters.AddWithValue("@charBackgroundBonus", character.charBackgroundBonus);
                        cmd.Parameters.AddWithValue("@charSkill1", character.charSkill1);
                        cmd.Parameters.AddWithValue("@charSkill2", character.charSkill2);
                        cmd.Parameters.AddWithValue("@charSkill3", character.charSkill3);
                        cmd.Parameters.AddWithValue("@skillPoints", character.skillPoints);
                        cmd.Parameters.AddWithValue("@statPoints", character.statPoints);
                        cmd.Parameters.AddWithValue("@charUID", character.charUID);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
                
            }
        }
        public bool SendMessage(string sender, string message)
        {

            string connectionString = "Server=localhost;Database=chat;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Insert the new message into the database
                string insertQuery = "INSERT INTO serverchat (sender, message, timestamp) VALUES (@sender, @message, NOW())";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@sender", sender);
                insertCmd.Parameters.AddWithValue("@message", message);

                insertCmd.ExecuteNonQuery();
                return true;  // Message successfully sent
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void PopulateChatBox(RichTextBox chatBox)
        {

            string connectionString = "Server=localhost;Database=chat;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            StringBuilder chatText = new StringBuilder();

            try
            {
                connection.Open();

                // Fetch the 25 most recent chat messages
                string fetchMessagesQuery = "SELECT sender, message, timestamp FROM serverchat ORDER BY timestamp DESC LIMIT 25";
                MySqlCommand fetchMessagesCmd = new MySqlCommand(fetchMessagesQuery, connection);

                MySqlDataReader reader = fetchMessagesCmd.ExecuteReader();

                while (reader.Read())
                {
                    string sender = reader.GetString("sender");
                    string message = reader.GetString("message");
                    DateTime timestamp = reader.GetDateTime("timestamp");

                    // Format the message
                    string formattedMessage = $"[{timestamp.ToString("HH:mm:ss")}] - {sender}: {message}\n";
                    chatText.Insert(0, formattedMessage);  // Insert at the beginning to display the most recent message last
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }

            // Populate the RichTextBox
            chatBox.Text = chatText.ToString();

            // Scroll to the bottom
        }
        public string CheckChatNickname(int accuid)
        {

            string connectionString = "Server=localhost;Database=chat;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string nickName = null;  // Initialize to null to indicate that no nickname was found

            try
            {
                connection.Open();

                // Fetch the nickname based on the accuid
                string fetchNicknameQuery = "SELECT nickName FROM chatusers WHERE UID = @accuid";
                MySqlCommand fetchNicknameCmd = new MySqlCommand(fetchNicknameQuery, connection);
                fetchNicknameCmd.Parameters.AddWithValue("@accuid", accuid);

                object result = fetchNicknameCmd.ExecuteScalar();

                if (result != null)
                {
                    nickName = result.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, show an error message, etc.)
            }
            finally
            {
                connection.Close();
            }

            return nickName;
        }

    }
}
