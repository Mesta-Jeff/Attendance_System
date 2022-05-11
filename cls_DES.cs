 
        public string EncryptionDES(string strText)
        {
            string strKey="AB14BB29";
            byte[] bykey = { };
            byte[] iv = { 0x01, 0x06, 0x06, 0x02, 0x09, 0x06, 0x02, 0x07 };
            try
            {
                bykey = Encoding.UTF8.GetBytes(strKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] input = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex) { }
            return null;
        }

        