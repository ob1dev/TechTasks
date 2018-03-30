Table: **Channels**

|Id       |Name         |Description  |Created |
|:-------:|:-----------:|:-----------:|:------:|
|PK, guid |nvarchar(256)|nvarchar(max)|datetime|

Table: **Articles**

|Id       |Name         |UserId  |ChannelId|Description  |Created |
|:-------:|:-----------:|:------:|:-------:|:-----------:|:------:|
|PK, guid |nvarchar(256)|FK, guid|FK, guid |nvarchar(max)|datetime|

Table: **Comments**

|Id       |Name         |UserId  |ArticleId|ParentId|Text         |Created |
|:-------:|:-----------:|:------:|:-------:|:------:|:-----------:|-------:|
|PK, guid |nvarchar(256)|FK, guid|FK, guid |FK, guid|nvarchar(max)|datetime|

Table: **Users**

|Id       |Name         |
|:-------:|:-----------:|
|PK, guid |nvarchar(256)|

> See the file `Reddit.dacpac` for more details of database schema.