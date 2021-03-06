﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantiss_Tests
{
    /// <summary>
    /// Сводное описание для AccountCreationTests
    /// </summary>
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void SetupConfig()
        {
            app.FTP.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(@"C:\Sofi\Mantis\CSharp_Mantis\Mantiss_Tests\config_inc.php", FileMode.Open))
            app.FTP.UploadFile("/config_inc.php", localFile);
        }

        [Test]
        public void AccountRegistrationTest()
        {
           

            AccountData account = new AccountData("testuser", "pass")
            {
                Email = "testuser@localhost.locsldomain"
            };

            List<AccountData> accounts = app.Auth.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Auth.DeleteAccount(existingAccount);
            }
            app.Registration.Register(existingAccount);
        }

        [TearDown]
        public void RestoreConfig()
        {
            app.FTP.RestoreBacupFile("/config_inc.php");
        }

    }
}
