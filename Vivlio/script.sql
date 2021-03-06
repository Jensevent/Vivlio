CREATE database vivlio
GO

USE [vivlio]
GO

/****** Object:  Table [dbo].[Author]    Script Date: 25/06/2021 16:43:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Birthdate] [date] NOT NULL,
	[Sex] [char](1) NOT NULL,
	[DateOfDeath] [date] NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 25/06/2021 16:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Author_ID] [int] NOT NULL,
	[Genre_ID] [int] NULL,
	[ISBN] [bigint] NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[Blurb] [varchar](max) NULL,
	[IsBorrowed] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 25/06/2021 16:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25/06/2021 16:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phonenumber] [int] NULL,
	[FuntionUser] [nvarchar](50) NOT NULL,
	[Birthdate] [date] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PasswordSalt] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBook]    Script Date: 25/06/2021 16:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Book_ID] [int] NOT NULL,
	[RetourDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[TimesProlonged] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (1, N'Herman Koch', CAST(N'1953-09-05' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (2, N'Paul van Loon', CAST(N'1955-04-17' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (3, N'William Gibson', CAST(N'1948-04-17' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (4, N'George Orwell', CAST(N'1903-06-25' AS Date), N'M', CAST(N'1950-01-21' AS Date))
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (5, N'Dmitry Glukhovsky', CAST(N'1979-06-12' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (6, N'Andrzej Sapkowski', CAST(N'1948-06-21' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (7, N'John Flanagan', CAST(N'1944-05-22' AS Date), N'M', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (8, N'Anne West', CAST(N'1974-02-20' AS Date), N'V', NULL)
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (9, N'Willy Vandersteen', CAST(N'1913-02-15' AS Date), N'M', CAST(N'1990-08-28' AS Date))
INSERT [dbo].[Author] ([ID], [Name], [Birthdate], [Sex], [DateOfDeath]) VALUES (10, N'Ernest Cline', CAST(N'1972-03-29' AS Date), N'M', NULL)
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (1, 2, 6, 19718389805362, N'Dolfje Weerwolfje 2 - Volle maan', CAST(N'2014-11-01' AS Date), N'Dolfje is met de klas op schoolkamp. Lekker keten, dolle pret! Op een avond zitten de kinderen om het kampvuur. Het is volle maan. De meester vertelt een eng verhaal. Opeens begint het bij Dolfje te kriebelen. Hij wordt weer wolf. Geschrokken rent hij naar het bos. Niemand mag zien wat hij is. Noura merkt wel dat er iets met Dolfje is. Stiekem achtervolgt ze hem...', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (2, 2, 6, 9149581774139, N'Dolfje Weerwolfje 8 - Dolfje Sneeuwwolfje', CAST(N'2008-02-01' AS Date), N'Dolfje en Noura rennen door het Weerwolvenbos. Het bos is wit. Overal ligt sneeuw. Dan vliegen er grote hopen sneeuw door de lucht. Dolfje en Noura vluchten weg. Net op tijd bereiken ze het huisje van Opa weerwolf. Daar wachte ze tot de sneeuw ophoudt. Om de tijd te doden vertellen ze verhalen. Over het nachtmerrieneefje. En over Knuppel, de weerwolfjager. Maar wie gooit toch die geheimzinnige sneeuwhopen? En wat ritselt daar in de schoorsteen...', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (3, 2, 6, 9426058931984, N'Dolfje Weerwolfje 20 - Spookweerwolven', CAST(N'2019-03-01' AS Date), N'In een luchtballon naar de (volle) maan! Dolfje Weerwolfje en Noura mogen mee in de luchtballon van neef Leo. Ze komen terecht op de binnenplaats van een duister kasteel. Daarbinnen klinken vreemde geluiden…', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (4, 2, 6, 6164641435104, N'Dolfje Weerwolfje 4 - Weerwolvenbos', CAST(N'2017-01-01' AS Date), N'Op een dag klinken er vreemde geluiden in het (Weer)Wolvenbos. Er wordt gehakt, gezaagd en gegraven. Het bos is in gevaar en ook de boomhut waarin Opa Weerwolf al jaren woont. Twee zakenmensen, Gratemager en Meneer willen alle bomen omhakken. Wat nu? Protesteren! Onder de naam W.R.O.W. (Wie Redt Ons Wolvenbos) richt Dolfje met zijn klas een actiegroep op. Maar of dat zal helpen?', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (5, 2, 6, 4981884450148, N'Dolfje Weerwolfje 11 - SuperDolfje', CAST(N'2014-04-01' AS Date), N'Er komt een zeer vreemde jongen met wild, gouden kapsel in de klas. Hij heeft een hekel aan Dolfje en Noura, want zij zijn anders. Wat nu? Alleen SuperDolfje kan voor redding zorgen...', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (6, 2, 6, 1173116731330, N'Weerwolvensoep', CAST(N'2020-04-01' AS Date), N'Dolfje is gevangen! Hoe redt hij zichzelf uit de soep? Dolfje verzint het ene verhaal na het andere, de hele weerwolfnacht lang. Maar is dat genoeg om Knuppel op andere gedachten te brengen?', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (7, 2, 6, 6405632217389, N'Dolfje Weerwolfje 12- Weerwolf(n)achtbaan', CAST(N'2012-09-01' AS Date), N'Dolfje en Noura gaan op schoolreisje naar de Efteling.
Terug bij school blijkt Noura weg.
Hoe kan dat? Dolfje wil meteen terug naar de Efteling.
Samen met opa weerwolf, Leo en Timmie.
Hij moet Noura vinden!
In de Efteling komen bij volle maan vreemde wezens tot leven.
Bovendien is er een gevaarlijke samenzwering…
Wat betekent de Nacht van de Macht van Acht?
En wat willen al die heksen?', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (8, 2, 6, 3905884647336, N'Dolfje Weerwolfje 10 - Weerwolfbende', CAST(N'2010-09-01' AS Date), N'Het is een duistere, donkere nacht. ''Pas op, Dolfje,'' zegt opa weerwolf.


''Er zijn... wezens op pad.'' Dolfje heeft ze ook gezien: enge schaduwen met scherpe oren.


Er wordt gegromd, gegrinnikt. En er gebeuren meer vreemde dingen.


Wat doet mevrouw Krijtjes in haar tuin met haar gietertje en rare plantjes? En wat is er met sommige klasgenootjes van Dolfje, die doodmoe zijn, de dag na volle maan?', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (9, 1, 5, 7683703108157, N'Het Diner', CAST(N'2017-02-01' AS Date), N'Twee echtparen gaan een avond uit eten in een restaurant. Ze praten over alledaagse dingen, dingen waar mensen tijdens etentjes over praten: werk, de laatste films, vakantieplannen. Maar ondertussen vermijden ze waar ze het eigenlijk over moeten hebben: hun kinderen. De twee vijftienjarige zoons van beide echtparen, Michel en Rick, hebben samen iets uitgehaald wat hun toekomst kan verwoesten. Tot dusver zijn alleen vage beelden van de twee in Opsporing verzocht vertoond en zit het onderzoek naar hun identiteit vast. Maar hoe lang nog? Wat de situatie nog ingewikkelder maakt is dat de vader van Rick de beoogde nieuwe minister-president van Nederland is.', 1)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (10, 1, 5, 8473922003319, N'Zomerhuis met zwembad', CAST(N'2017-02-01' AS Date), N'Huisarts Marc Schlosser heeft een medische fout begaan waardoor een van zijn patiënten, de beroemde acteur Ralph Meier, is overleden. Hij zal zich moeten verantwoorden voor de Medische Tuchtraad. Over die Tuchtraad maakt hij zich niet echt zorgen: Een schorsing van een paar maanden, daar komt het op neer. We kennen elkaar allemaal, meer zal het niet worden. Maar is het wel een medische fout? Marc had immers een rekening te vereffenen met zijn patiënt, die net iets te veel belangstelling toonde voor diens mooie vrouw Caroline. Of heeft het alles te maken met de gebeurtenissen in het zomerhuis waar het echtpaar Meier het gezin Schlosser had uitgenodigd? In Zomerhuis met zwembad vertelt de hoofdpersoon met niets en niemand ontziende eerlijkheid hoe hij op dit punt in zijn leven is aanbeland. Het is het spannende, maar ook geestige verhaal over het recht op vergelding en het overschrijden van grenzen als de deuren naar een normale rechtsgang zijn dichtgeslagen.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (11, 3, 7, 4740984561345, N'Neuromancer', CAST(N'2013-01-01' AS Date), N'Case had been the sharpest data-thief in the business, until vengeful former employees crippled his nervous system. But now a new and very mysterious employer recruits him for a last-chance run. The target: an unthinkably powerful artificial intelligence orbiting Earth in service of the sinister Tessier-Ashpool business clan. With a dead man riding shotgun and Molly, mirror-eyed street-samurai, to watch his back, Case embarks on an adventure that ups the ante on an entire genre of fiction.
Hotwired to the leading edges of art and technology, Neuromancer ranks with 1984 and Brave New World as one of the century''s most potent visions of the future.', 1)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (12, 3, 7, 8676965962141, N'Agency', CAST(N'2020-01-01' AS Date), N'2017: in an alternate time track, Hillary Clinton won the election and Donald Trump''s political ambitions were thwarted. London, 22nd century. Decades of cataclysmic events have killed 80% of humanity. A shadowy start-up hires a woman to test a new product: a ‘personal avatar''. A thrilling dystopian novel imagining a world where Trump lost the election, from the master of science fiction.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (13, 4, 7, 8456666103340, N'1984', CAST(N'2008-01-01' AS Date), N'Written more than 70 years ago, 1984 was George Orwell’s chilling prophecy about the future. And while 1984 has come and gone, his dystopian vision of a government that will do anything to control the narrative is timelier than ever...', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (14, 4, 7, 1167781604247, N'Animal Farm', CAST(N'2008-01-01' AS Date), N'''All animals are equal. But some animals are more equal than others.'' Mr Jones of Manor Farm is so lazy and drunken that one day he forgets to feed his livestock. The ensuing rebellion under the leadership of the pigs Napoleon and Snowball leads to the animals taking over the farm. Vowing to eliminate the terrible inequities of the farmyard, the renamed Animal Farm is organised to benefit all who walk on four legs. But as time passes, the ideals of the rebellion are corrupted, then forgotten. And something new and unexpected emerges. . .', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (15, 5, 7, 2760461858709, N'Metro 2033', CAST(N'2011-06-01' AS Date), N'The year is 2033. The world has been reduced to rubble. Humanity is nearly extinct. The half-destroyed cities have become uninhabitable through radiation. Beyond their boundaries, they say, lie endless burned-out deserts and the remains of splintered forests. Survivors still remember the past greatness of humankind. But the last remains of civilisation have already become a distant memory, the stuff of myth and legend. More than 20 years have passed since the last plane took off from the earth. Rusted railways lead into emptiness. The ether is void and the airwaves echo to a soulless howling where previously the frequencies were full of news from Tokyo, New York, Buenos Aires. Man has handed over stewardship of the earth to new life-forms. Mutated by radiation, they are better adapted to the new world. Man''s time is over. A few score thousand survivors live on, not knowing whether they are the only ones left on earth. They live in the Moscow Metro - the biggest air-raid shelter ever built. It is humanity''s last refuge. Stations have become mini-statelets, their people uniting around ideas, religions, water-filters - or the simple need to repulse an enemy incursion. It is a world without a tomorrow, with no room for dreams, plans, hopes. Feelings have given way to instinct - the most important of which is survival. Survival at any price. VDNKh is the northernmost inhabited station on its line. It was one of the Metro''s best stations and still remains secure. But now a new and terrible threat has appeared. Artyom, a young man living in VDNKh, is given the task of penetrating to the heart of the Metro, to the legendary Polis, to alert everyone to the awful danger and to get help. He holds the future of his native station in his hands, the whole Metro - and maybe the whole of humanity.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (16, 6, 7, 1782463554810, N'The Witcher - The Last Wish', CAST(N'2020-01-01' AS Date), N'Geralt the Witcher -- revered and hated -- holds the line against the monsters plaguing humanity in this collection of adventures in the New York Times bestselling series that inspired the Netflix show and the hit video games. Geralt is a Witcher, a man whose magic powers, enhanced by long training and a mysterious elixir, have made him a brilliant fighter and a merciless assassin. Yet he is no ordinary murderer: his targets are the multifarious monsters and vile fiends that ravage the land and attack the innocent. But not everything monstrous-looking is evil and not everything fair is good...and in every fairy tale there is a grain of truth.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (17, 7, 6, 9903396536454, N'De Grijze Jager 1 - De ruines van Gorlan', CAST(N'2015-12-01' AS Date), N'Will is klein voor zijn leeftijd, maar razendsnel en niet dom. Zijn hele leven heeft hij ervan gedroomd om ridder te worden, net als zijn vader, die hij nooit heeft gekend. Hij is dan ook hevig teleurgesteld als hij afgewezen wordt voor de krijgsschool van kasteel Redmont. In plaats daarvan wordt hij toegewezen aan Halt, de mysterieuze Grijze Jager wiens grootste talent lijkt te zijn dat hij zich onopvallend door het rijk kan verplaatsen. Met enige weerzin leert Will om de geheime wapens van de Grijze Jagers te gebruiken: pijl en boog, een onopvallende camouflagecape en een eigenwijze kleine pony. Ook al verlangt Will hevig naar een zwaard en een stoer strijdpaard, als hij samen met Halt op een geheime missie gaat om de moord op de koning te voorkomen, komt hij erachter dat de wapens van de Grijze Jagers zo slecht nog niet zijn De ruïnes van Gorlan is het eerste deel in de Grijze Jager-serie over Will en zijn vrienden van kasteel Redmont.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (18, 7, 6, 8927068341114, N'De Grijze Jager 5 - De magiër van Macindaw', CAST(N'2008-07-01' AS Date), N'De inwoners van Skandia en Araluen leven inmiddels alweer vijf jaar in vrede met elkaar. Will heeft, nu hij zelf tot Grijze Jager is bevorderd, de verantwoordelijkheid over een eigen leen. Al snel blijkt dat hij, ook als leenheer, op zijn hoede moet blijven. Niet alleen zijn eigen stukje land kent problemen, ook in het hoge Noorden rommelt het. Daar schijnt een afgelegen leen te worden geteisterd door duistere magische krachten. Samen met zijn vriendin Alyss gaat hij op onderzoek uit, om tot de ontdekking te komen dat er wel heel erg onverklaarbare dingen gebeuren.', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (23, 8, 6, 1029579502918, N'De Macht van het Zwaard - De aardmagiër / De watermagiër', CAST(N'2009-10-01' AS Date), N'Cyane is voorbestemd te trouwen met graaf Thorvald. Maar Meroboth, bezitter van de groene diamant en jongste van een tovenaarsdrieling, heeft grootsere plannen met haar. Deze aardmagiër is ervan overtuigd dat alleen Cyane het magische zwaard kan hanteren en dat zij de Zwarte Magiër kan verslaan. Samen met Meroboth gaat Cyane op zoek naar zijn drieklingbroers en hun diamanten die het zwaard magische kracht geven. Onderweg leert ze de kneepjes van de aardmagie. Een zinderende zoektocht naar de bezitter van de blauwe diamant, de watermagiër, begint...', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (24, 8, 6, 3418214032573, N'De Macht van het Zwaard - De vuurmagiër / De Zwarte Magiër', CAST(N'2007-07-01' AS Date), N'Samen met de aard- en de watermagiër is Cyane op zoek naar hun drielingbroer, de vuurmagiër. Alleen als zij hun krachten weten te bundelen, maakt Cyane een kans tegen de zwarte magiër. Diep in het Rijk der Duisternis sluit Tiron, haar geliefde, zich voor haar af. Wat beweegt hem? In de gruwelijke kelders van Ikors paleis stuit Cyane op de meestersmid. Hij heeft een wapen gesmeed voor de drager van het Zwaard der Zwarte Magie. Eindelijk ontmoet Cyane haar tegenstander; zij is verbijsterd. Er breekt een gevecht op leven en dood uit. Wie van hen kan het navertellen', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (25, 9, 8, 2911380052657, N'Suske en Wiske - Het Spaanse Spook', CAST(N'1984-01-01' AS Date), N'Het spookt in het museum! Lambik, Suske en Wiske ontmoeten er het Spaanse spook. Ze worden meegenomen naar zijn tijdperk waar ze moeten strijden tegen de hertog van Alva om het dorp Kriekebeek te redden. Zijn onze vrienden sterk genoeg om het op te nemen tegen de Spaanse strijders?', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (26, 9, 8, 6973841856887, N'Suske en Wiske - De Zappende Ziel', CAST(N'2011-03-01' AS Date), N'Wanneer Lambik op een dag zichzelf vanuit het verleden wil terugflitsen naar het heden neemt hij, zonder het te beseffen, een onzichtbare geest met zich mee. Plots blijken allerlei voorwerpen tot leven te komen wat het leven van onze vrienden danig op zijn kop te zet. De geest is blijkbaar de ziel van een vreemdsoortig wezen dat ooit in het oude Griekenland leefde. Hij is al jaren vruchteloos op zoek naar zijn geliefde en de wanhoop nabij. Natuurlijk willen Suske en Wiske en hun vrienden de arme ziel helpen: ze vertrekken naar het oude Griekenland. Daar wil koning Demetrios koste wat het kost de stad Rhodos veroveren waarbij hij geen enkel middel schuwt, ook al leidt dit tot de ondergang van de verliefde zielen. Wat volgt is een wervelend avontuur waarin onze vrienden het opnemen tegen allerlei gevaarlijke Griekse creaturen!', 0)
INSERT [dbo].[Book] ([ID], [Author_ID], [Genre_ID], [ISBN], [Title], [ReleaseDate], [Blurb], [IsBorrowed]) VALUES (28, 10, 7, 2737598941909, N'Ready Player One', CAST(N'2012-03-01' AS Date), N'It''s the year 2044, and the real world has become an ugly place. We''re out of oil. We''ve wrecked the climate. Famine, poverty, and disease are widespread. Like most of humanity, Wade Watts escapes this depressing reality by spending his waking hours jacked into the OASIS, a sprawling virtual utopia where you can be anything you want to be, where you can live and play and fall in love on any of ten thousand planets. And like most of humanity, Wade is obsessed by the ultimate lottery ticket that lies concealed within this alternate reality: OASIS founder James Halliday, who dies with no heir, has promised that control of the OASIS - and his massive fortune - will go to the person who can solve the riddles he has left scattered throughout his creation. For years, millions have struggled fruitlessly to attain this prize, knowing only that the riddles are based in the culture of the late twentieth century. And then Wade stumbles onto the key to the first puzzle. Suddenly, he finds himself pitted against thousands of competitors in a desperate race to claim the ultimate prize, a chase that soon takes on terrifying real-world dimensions - and that will leave both Wade and his world profoundly changed.', 0)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (1, N'Superhelden')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (2, N'Science-fiction')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (3, N'Fantasie')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (4, N'Oorlog')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (5, N'Roman')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (6, N'Kinderen')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (7, N'Engels')
INSERT [dbo].[Genre] ([ID], [Genre]) VALUES (8, N'Stripverhalen')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (1, N'Jens', N'jensevent', N'jens@gmail.com', NULL, N'Employee', CAST(N'2002-02-23' AS Date), N'8DKvZhOuniIst9etq4UBbcm1UlkI9awMB5RmPyxePgZFcGV/3vhJLimuqlV9dAIyP3w8KtyVR+TbYgfV739tzyCBupKyjD5fzV4cjZyz75hgh7FnGsO9G6J3c+OoCO2NOY4xEW/algR5ZhEmRvZS7xx9CukW4P3kbFfFic9mWNgdhoQT6EuWrmU9DEBawYMQL9IfvZ29r4jmAVr4XJS5eJi5PGmy5LQ0RtQS5BF0NUGh9OoivY+huHWXu+MELT6B8lksdC6S2Fc9KXp0spwLuD6bXY5JCJCxKtX3RFw6z3xjsblB0H0MCRe6xjIgfUvTFJt3gGhw6W/y/GPvYPcYoA==', N'+2Do/nnx9HAX4Utrp9xudNebhyyq3ORFDRq8RWf3YsazN5OUcP5Av33hqXWdM/1tSz1wEKTYHxgiOhTsZfSzoQ==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (2, N'Sem', N'S0LSTICE', N'sem@gmail.com', NULL, N'Employee', CAST(N'2000-09-15' AS Date), N'8DKvZhOuniIst9etq4UBbcm1UlkI9awMB5RmPyxePgZFcGV/3vhJLimuqlV9dAIyP3w8KtyVR+TbYgfV739tzyCBupKyjD5fzV4cjZyz75hgh7FnGsO9G6J3c+OoCO2NOY4xEW/algR5ZhEmRvZS7xx9CukW4P3kbFfFic9mWNgdhoQT6EuWrmU9DEBawYMQL9IfvZ29r4jmAVr4XJS5eJi5PGmy5LQ0RtQS5BF0NUGh9OoivY+huHWXu+MELT6B8lksdC6S2Fc9KXp0spwLuD6bXY5JCJCxKtX3RFw6z3xjsblB0H0MCRe6xjIgfUvTFJt3gGhw6W/y/GPvYPcYoA==', N'+2Do/nnx9HAX4Utrp9xudNebhyyq3ORFDRq8RWf3YsazN5OUcP5Av33hqXWdM/1tSz1wEKTYHxgiOhTsZfSzoQ==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (3, N'Wesley', N'Tarzan', N'Wesley@gmail.com', NULL, N'Admin', CAST(N'1980-03-11' AS Date), N'8DKvZhOuniIst9etq4UBbcm1UlkI9awMB5RmPyxePgZFcGV/3vhJLimuqlV9dAIyP3w8KtyVR+TbYgfV739tzyCBupKyjD5fzV4cjZyz75hgh7FnGsO9G6J3c+OoCO2NOY4xEW/algR5ZhEmRvZS7xx9CukW4P3kbFfFic9mWNgdhoQT6EuWrmU9DEBawYMQL9IfvZ29r4jmAVr4XJS5eJi5PGmy5LQ0RtQS5BF0NUGh9OoivY+huHWXu+MELT6B8lksdC6S2Fc9KXp0spwLuD6bXY5JCJCxKtX3RFw6z3xjsblB0H0MCRe6xjIgfUvTFJt3gGhw6W/y/GPvYPcYoA==', N'+2Do/nnx9HAX4Utrp9xudNebhyyq3ORFDRq8RWf3YsazN5OUcP5Av33hqXWdM/1tSz1wEKTYHxgiOhTsZfSzoQ==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (4, N'Diana', N'WonderWoman', N'Dian@gmail.com', NULL, N'Member', CAST(N'1922-12-12' AS Date), N'8DKvZhOuniIst9etq4UBbcm1UlkI9awMB5RmPyxePgZFcGV/3vhJLimuqlV9dAIyP3w8KtyVR+TbYgfV739tzyCBupKyjD5fzV4cjZyz75hgh7FnGsO9G6J3c+OoCO2NOY4xEW/algR5ZhEmRvZS7xx9CukW4P3kbFfFic9mWNgdhoQT6EuWrmU9DEBawYMQL9IfvZ29r4jmAVr4XJS5eJi5PGmy5LQ0RtQS5BF0NUGh9OoivY+huHWXu+MELT6B8lksdC6S2Fc9KXp0spwLuD6bXY5JCJCxKtX3RFw6z3xjsblB0H0MCRe6xjIgfUvTFJt3gGhw6W/y/GPvYPcYoA==', N'+2Do/nnx9HAX4Utrp9xudNebhyyq3ORFDRq8RWf3YsazN5OUcP5Av33hqXWdM/1tSz1wEKTYHxgiOhTsZfSzoQ==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (5, N'Klaas', N'KlaasVaak', N'KlaasHoudtVanKaas@gmail.com', NULL, N'Member', CAST(N'2002-02-23' AS Date), N'cMTt1WVppCNNGBVCP1WkgY0Fn3vtfKGXfLAhL6ivEvAYWA5lgdqfK+QuYgdaqRAB62Sxr4WiFYK6h1Wl/ocgaQL/gavYMzN7VdkfIRU+1NrH0LymvrM0JfzvzC0wkV9L9ICpYQPQWGOuCYQTTnY/BUnPCenc32855megpgcSSdu8qNse/eGbc0z7HsOBZgFx++EZk2m0iFks/aqxzsnnNcjBi/MWsp33n3M6PEsY/EKHjjT3AnKFRennkLSnXoLps7Y9BaxxEdojryy626+EZ7Lp5SGWs3/iGlR/oxdZhFYmCtIkRWr3hSFtoCZ7AuCDkChYVD6BFFYeMrr6ngolzg==', N'MR4f6QKQ/fZHlgJEYeJIO9/Jr9hCh14TLEqbH9DrI1jkcIP3pZpQCjIS/0I3xUPqCLwFqNZamHm+sEq96tOB0Q==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (10, N'Remco', N'BobDeBouwer', N'bob@gmail.com', NULL, N'Admin', CAST(N'2002-02-23' AS Date), N'Wu+IKBVnUoY7JEI4igbCYXU5OCQMCU3sPBqSX5p4Jowd0ktY7xCpjK2FrbwYfuhiBNCMetuYqJ10YJosLlVYa3xkFMgIRbgujlCoPXt4p7OpJvXq8HmRnq9cgEwzYVStMcY01cPwdS7/RQbDqmsrxIIGJ7Ckw2bmsrKrOrxSbsjjY9AljjXMr+E8xIjsZ3Ckx0jbPkC8nWYBW2upKWxuDu+CoMiZjrGVWimNmWA8LKu/C4C13LowTC3jSfMGlPFh/Z0UC9aCMw5eFMdW9U9wOMhJRSU0aeI0xshgxAxgg4Ieiptyj+OR6rk1AgQYy87Apo/vsQj0CmhUNcyHNYFyGw==', N'eiNHWOiGzeePphosCA65yH894I6s8IUDS4GyCafOD8y/hwmhbj7MIIeNjyDHaWpnZt6OQp+HiK8zs9VvVtJYqA==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (11, N'Youss', N'AlphaYouss', N'youss@gmail.com', 1122334455, N'Member', CAST(N'2002-06-11' AS Date), N'I8Dbk0Q1yMm7OE1NtdkAdd4nGnD5vQ9VSEB1mjS9cSFk9hKDz442LO2FBsgcsREQ9KmH+GDbjucNaw2GkNB04YT5LT8hGsf/haH8+OK/5wQxr3ERLod9ELljLpgvO9lgCfyuFC8R5rQCi34Kxv4UjOxsBGA5gMpw79MfPEltaOv9Tbxlv1dYvwxQFSZxaeK39u5BfuUwQO4oL/xUxUwttxfFdxE3/uMtjvot+BI3C3axNroncs0FoRcnOedNoAy0XcSonRYqjics6wafFb+cBEr/4Yhvggs+UeSkYLu52mM3bS546gJbxIB64hIZFVyaU4zQ21o1uqYLnEXpvaXF3w==', N'wDdnnOdFg0E0yDFHsKQzhkKdBC2AbSGojJx7v/aH9u1laE2CrRkzmD+gHl6RXhYfNIHCnuyE3c0oMu3JoSvn1Q==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (12, N'Adrian', N'Prometheus', N'Karin@design.nl', 609091336, N'Member', CAST(N'2000-06-19' AS Date), N'VuJYAqQz+tMH8lT7R+1HLSTJwah+M94IvGyPJVRxBMRbVk2thEbDGxo2ozSXgpc6z0Iwn6zg8r+F1Kh9LElqsgFYeMF5ITdbZKQUen2llORh48P1Ye52G13OnunYnlytUbtzSkPL20yAdp1hoh/lguDQAHBUY9m/f1OxInSvpa2rfjrsJjFUeKrKWE/R2Nv9lnmIdA/MzZnzYMcUeqvQGwGcZzX8dOjwrEN2YWNlggX7afljq2QZtmMXb+/aiitpn1bd+XetIWnZiTG93yNQCeVdfPESGcwtWY7qWpcZCydP1UqcJSxkY7vbFThv32zMEJ9pVByxQy5RT+YhwsAfpg==', N'O/qdfXXQh0lYsrbwPmT9cKxbxgVB7Jq8IvFpa9X8i4S3hUerNlU4lV03YMRguFx3zUckTAcOnALJR5Tz6m6Pcw==')
INSERT [dbo].[User] ([ID], [Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt]) VALUES (13, N'Bruce', N'Batman', N'BruceWayne@gmail.com', 609091336, N'Member', CAST(N'2000-03-30' AS Date), N'd3oQMVmR8yWzX3e62qZo8uvKNz0+GRgds06UhyqshKNUchGrOP0esrtolP/W7QvElwEuSA80g7bGrpSopsauezA1Qs3iv1XCo7+qPpW4sRryZtU/3yeZfBvln70oeA5gTCBjDM5V8nt3ervG3FxtIW4d5UJjeTBQaqv/SNkaL19VDtW5gW5weLjekQ5lsOJirSSP/RnhSpOtCcqryJofphzmUmIhhXvuVPQLLdsDSKa9gMNEmvbtNes/daS6oalVcCkOlN5gr718n2zL3qTnpIVzsdmREBK3JEaLRs1+wZSeh78ZbH8kyB1GTfdA4TaJ9/IJXbbyvMbgfoKAsSJj3A==', N'FCHEQ8n/Oi0zQR9pj+V/zbEaUtW/ub0rl2ilkR+18OGnkWpu1+fHTUOjMlgKrJKPptDXOCisXu4+QUgf9Gqnmw==')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserBook] ON 

INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (1, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (2, 3, 2, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (3, 4, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-05-18' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (4, 4, 5, CAST(N'2020-06-30' AS Date), CAST(N'2020-05-18' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (5, 2, 4, CAST(N'2020-06-30' AS Date), CAST(N'0200-01-01' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (6, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (7, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (8, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (9, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (10, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (11, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (12, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (13, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (14, 2, 2, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (15, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (16, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (17, 4, 4, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (18, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (19, 3, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (20, 3, 5, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (21, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (22, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (24, 1, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-17' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (25, 2, 2, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (32, 3, 2, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (33, 3, 11, CAST(N'2012-07-02' AS Date), CAST(N'2020-06-19' AS Date), 3)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (34, 2, 17, CAST(N'2020-07-02' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (35, 3, 15, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (36, 3, 8, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (37, 3, 23, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (43, 1, 11, CAST(N'2020-07-10' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (44, 12, 26, CAST(N'2020-07-10' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (45, 1, 9, CAST(N'2020-06-13' AS Date), NULL, 2)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (46, 1, 16, CAST(N'2020-07-14' AS Date), CAST(N'2020-06-23' AS Date), 3)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (47, 1, 11, CAST(N'2020-07-14' AS Date), NULL, 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (48, 2, 4, CAST(N'2021-02-03' AS Date), CAST(N'2021-01-13' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (26, 3, 23, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (27, 3, 2, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (28, 3, 4, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (29, 3, 5, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (30, 3, 11, CAST(N'2020-06-30' AS Date), CAST(N'2020-06-09' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (38, 3, 2, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (39, 3, 4, CAST(N'2020-07-06' AS Date), CAST(N'2020-06-19' AS Date), 1)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (40, 3, 14, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (41, 3, 9, CAST(N'2020-07-09' AS Date), CAST(N'2020-06-19' AS Date), 1)
INSERT [dbo].[UserBook] ([ID], [User_ID], [Book_ID], [RetourDate], [ReturnDate], [TimesProlonged]) VALUES (42, 3, 18, CAST(N'2020-07-03' AS Date), CAST(N'2020-06-19' AS Date), 0)
SET IDENTITY_INSERT [dbo].[UserBook] OFF
GO
/****** Object:  Index [FK_Author_ID]    Script Date: 25/06/2021 16:43:03 ******/
CREATE NONCLUSTERED INDEX [FK_Author_ID] ON [dbo].[Book]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH NOCHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([ID])
REFERENCES [dbo].[Author] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Book] NOCHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Book] FOREIGN KEY([Genre_ID])
REFERENCES [dbo].[Genre] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Book]
GO
ALTER TABLE [dbo].[UserBook]  WITH CHECK ADD  CONSTRAINT [FK_UserBook_Book_ID] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[UserBook] CHECK CONSTRAINT [FK_UserBook_Book_ID]
GO
ALTER TABLE [dbo].[UserBook]  WITH CHECK ADD  CONSTRAINT [FK_UserBook_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserBook] CHECK CONSTRAINT [FK_UserBook_User_ID]
GO
USE [master]
GO
ALTER DATABASE [vivlio] SET  READ_WRITE 
GO
