﻿using LibSnaffle.Classifiers.Rules;
using System.Collections.Generic;

namespace LibSnaffle.Classifiers
{
    public partial class ClassifierRules
    {
        private void BuildFileContentRules()
        {
            // Python
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for python related strings.",
                RuleName = "PyContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepPyRegexRed",
                WordList = new List<string>()
                {
                    // python
                    ".py"
                },
            });

            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepPyRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // python
                    //"mysql\\.connector\\.connect\\(", //python
                    //"psycopg2\\.connect\\(", // python postgres
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });
            // PHP
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for php related strings.",
                RuleName = "phpContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepPhpRegexRed",
                WordList = new List<string>()
                {
                    // php
                    ".php",
                    ".phtml",
                    ".inc",
                    ".php3",
                    ".php5",
                    ".php7"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepPhpRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // php
                    //"mysql_connect[[:space:]]*\\(.*\\$.*\\)", // php
                    //"mysql_pconnect[[:space:]]*\\(.*\\$.*\\)", // php
                    //"mysql_change_user[[:space:]]*\\(.*\\$.*\\)", // php
                    //"pg_connect[[:space:]]*\\(.*\\$.*\\)", // php
                    //"pg_pconnect[[:space:]]*\\(.*\\$.*\\)", // php
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });
            // CSharp
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for CSharp and ASP.NET related strings.",
                RuleName = "csContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepCsRegexRed",
                WordList = new List<string>()
                {
                    // asp.net
                    ".aspx",
                    ".ashx",
                    ".asmx",
                    ".asp",
                    ".cshtml",
                    ".cs",
                    ".ascx"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepCsRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // csharp
                    "connectionstring.{1,200}passw",
                    "validationkey[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "decryptionkey[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });
            //Java
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for Java and ColdFusion related strings.",
                RuleName = "javaContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepJavaRegexRed",
                WordList = new List<string>()
                {
                    // java
                    ".jsp",
                    ".do",
                    ".java",
                    // coldfusion
                    ".cfm",
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepJavaRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // java
                    //"\\.getConnection\\(\\\"jdbc\\:",
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });
            // Ruby
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for Rubby related strings.",
                RuleName = "rubyContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepRubyRegexRed",
                WordList = new List<string>()
                {
                    // ruby
                    ".rb"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepRubyRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // ruby
                    //"DBI\\.connect\\(",
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });

            // Perl
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for Perl related strings.",
                RuleName = "perlContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepPerlRegexRed",
                WordList = new List<string>()
                {
                    // perl
                    ".pl"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepPerlRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // perl
                    //"DBI\\-\\>connect\\(",
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });

            // PowerShell
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for PowerShell related strings.",
                RuleName = "psContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepPsRegexRed",
                WordList = new List<string>()
                {
                    // powershell
                    ".psd1",
                    ".psm1",
                    ".ps1",
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepPsRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // PS
                    "net user ",
                    "psexec .{0-100} -p ",
                    "-SecureString",
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,00} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });

            // Batch
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for cmd.exe/batch file related strings.",
                RuleName = "cmdContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepCmdRegexRed",
                WordList = new List<string>()
                {
                    // cmd.exe
                    ".bat"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepCmdRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // cmd
                    "net user ",
                    "psexec .{0-100} -p "
                }
            });

            // bash/sh/zsh/etc
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for Bash related strings.",
                RuleName = "bashContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepBashRegexRed",
                WordList = new List<string>()
                {
                    // bash, sh, zsh, etc
                    ".sh",
                    ".rc",
                    ".profile"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepBashRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // bash
                    "sshpass -p.*['|\\\"]", //SSH Password
                    // generic tokens etc, same for most languages.
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                }
            });
            // Firefox/Thunderbird backups
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for Firefox/Thunderbird backups related strings.",
                RuleName = "browerContentByName",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileName,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepFFRegexRed",
                WordList = new List<string>()
                {
                    // Firefox/Thunderbird
                    "logins.json"
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexes are very interesting.",
                RuleName = "KeepFFRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    "\"encryptedPassword\":\"[A-Za-z0-9+/=]+\""
                }
            });

            // vbscript etc
            /*
            this.ClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be searched for VBScript related strings.",
                RuleName = "vbsContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepVbsRegexRed",
                WordList = new List<string>()
                {
                    ".vbs",
                    ".wsf"
                },
            });
            this.ClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with contents matching these regexen are very interesting.",
                RuleName = "KeepVbsRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    // TODO LOL
                }
            });
            */

            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be subjected to a generic search for keys and such.",
                RuleName = "ConfigContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepConfigRegexRed",
                WordList = new List<string>()
                {
                    ".yaml",
                    ".yml",
                    ".toml",
                    ".xml",
                    ".json",
                    ".config",
                    ".ini",
                    ".inf",
                    ".cnf",
                    ".conf",
                    ".properties",
                    ".env",
                    ".dist",
                    ".txt",
                    ".sql",
                    ".log",
                    ".sqlite",
                    ".sqlite3",
                    ".fdb",
                    ""
                },
            });

            AllClassifierRules.Add(new ClassifierRule()
            {
                RuleName = "KeepConfigRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    "sqlconnectionstring[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "connectionstring[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "validationkey[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "decryptionkey[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "passwo?r?d[[:space:]]*=[[:space:]]*[\\\'\\\"][^\\\'\\\"].....*",
                    "CREATE (USER|LOGIN) .{0,200} (IDENTIFIED BY|WITH PASSWORD)", // sql creds
                    //"(xox[pboa]-[0-9]{12}-[0-9]{12}-[0-9]{12}-[a-z0-9]{32})", //Slack Token
                    //"https://hooks.slack.com/services/T[a-zA-Z0-9_]{8}/B[a-zA-Z0-9_]{8}/[a-zA-Z0-9_]{24}", //Slack Webhook
                    //"aws[_\\-\\.]?key", // aws mnagic
                    //"[_\\-\\.]?api[_\\-\\.]?key", // stuff
                    //"[_\\-\\.]oauth[[:space:]]*=", // oauth stuff
                    //"client_secret", // fun
                    //"secret[_\\-\\.]?(key)?[[:space:]]*=",
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----",
                    "(\\s|\\\'|\\\"|\\^|=)(A3T[A-Z0-9]|AKIA|AGPA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}(\\s|\\\'|\\\"|$)", // aws access key
                    // network device config
                    "NVRAM config last updated",
                    "enable password .",
                    "simple-bind authenticated encrypt",
                },
            });
            AllClassifierRules.Add(new ClassifierRule()
            {
                Description = "Files with these extensions will be grepped for private keys.",
                RuleName = "CertContentByExt",
                EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                MatchLocation = Constants.MatchLoc.FileExtension,
                WordListType = Constants.MatchListType.Exact,
                MatchAction = Constants.MatchAction.Relay,
                RelayTarget = "KeepCertRegexRed",
                WordList = new List<string>()
                {
                    "_rsa", // test file created
                    "_dsa", // test file created
                    "_ed25519", // test file created
                    "_ecdsa", // test file created
                    ".pem",
                },
            });

            AllClassifierRules.Add(new ClassifierRule()
            {
                RuleName = "KeepCertRegexRed",
                EnumerationScope = Constants.EnumerationScope.ContentsEnumeration,
                MatchLocation = Constants.MatchLoc.FileContentAsString,
                WordListType = Constants.MatchListType.Regex,
                MatchAction = Constants.MatchAction.Snaffle,
                Triage = Constants.Triage.Red,
                WordList = new List<string>()
                {
                    "-----BEGIN( RSA| OPENSSH| DSA| EC| PGP)? PRIVATE KEY( BLOCK)?-----"
                },
            });

            // dsa | ecdsa | ed25519 | rsa]
            AllClassifierRules.Add(
                new ClassifierRule()
                {
                    Description = "Files with these extensions will be parsed as x509 certificates to see if they have private keys.",
                    RuleName = "KeepCertContainsPrivKeyRed",
                    EnumerationScope = Constants.EnumerationScope.FileEnumeration,
                    MatchLocation = Constants.MatchLoc.FileExtension,
                    WordListType = Constants.MatchListType.Exact,
                    MatchAction = Constants.MatchAction.CheckForKeys,
                    Triage = Constants.Triage.Red,
                    WordList = new List<string>()
                    {
                        ".der",   // test file created
                        ".pfx",
                        ".pk12",
                        ".p12",
                        ".pkcs12",
                    },
                }
            );
        }
    }
}
