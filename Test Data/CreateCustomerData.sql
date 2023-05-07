USE EasyAppointmentManager
GO

/****** Object: Create Table Customer  ******/   
DROP TABLE IF EXISTS Customer 
GO
CREATE TABLE Customer (
	CustomerId INT,
	FirstName VARCHAR(50),
	MiddleName VARCHAR(50),
	LastName VARCHAR(50),
	DateOfBirth DATE,
	Gender BIT,
	PhoneNumber VARCHAR(50),
	Email VARCHAR(50)
);
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (1, 'Maurise', 'Berke', 'Taborre', '10/20/1994', 'True', '(970) 3778982', 'btaborre0@mit.edu');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (2, 'Mitchell', 'Sterne', 'Cardozo', '09/21/1991', 'True', '(347) 2659942', 'scardozo1@people.com.cn');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (3, 'Robinet', 'Burg', 'McMorland', '04/16/1970', 'True', '(424) 5567782', 'bmcmorland2@geocities.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (4, 'Wilhelm', 'Hobart', 'Yoxall', '09/21/1983', 'True', '(624) 7227735', 'hyoxall3@twitpic.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (5, 'Modesty', 'Jock', 'Smeeton', '05/26/1978', 'False', '(208) 6118894', 'jsmeeton4@merriam-webster.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (6, 'Creight', 'Julius', 'Felmingham', '10/05/1964', 'True', '(143) 6959916', 'jfelmingham5@usa.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (7, 'Lauren', 'Ariela', 'Weadick', '10/12/1983', 'False', '(919) 8330276', 'aweadick6@ed.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (8, 'Pierrette', 'Wilie', 'Cortese', '10/03/1963', 'False', '(339) 4109610', 'wcortese7@desdev.cn');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (9, 'Dick', 'Jodi', 'Origan', '12/28/1970', 'True', '(615) 5060658', 'jorigan8@oaic.gov.au');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (10, 'Marna', 'Gwynne', 'Heffernon', '08/24/1978', 'False', '(359) 8637110', 'gheffernon9@google.nl');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (11, 'Zackariah', 'Currie', 'Gethins', '06/14/1974', 'True', '(370) 7302109', 'cgethinsa@paypal.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (12, 'Wandis', 'Corabel', 'Paviour', '08/14/1985', 'False', '(635) 7415665', 'cpaviourb@google.nl');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (13, 'Myrta', 'Sigfrid', 'Relf', '09/26/1968', 'False', '(712) 8740279', 'srelfc@spiegel.de');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (14, 'Tabb', 'Ginger', 'Colkett', '11/07/1985', 'True', '(570) 7958169', 'gcolkettd@mashable.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (15, 'Padriac', 'Obidiah', 'Pulbrook', '08/03/1987', 'True', '(624) 9703596', 'opulbrooke@amazonaws.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (16, 'Vyky', 'Amery', 'Leuchars', '11/25/1987', 'False', '(293) 5571382', 'aleucharsf@sbwire.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (17, 'Brittney', 'Ciel', 'Backen', '07/12/1992', 'False', '(854) 9686008', 'cbackeng@sun.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (18, 'Ennis', 'Levin', 'Fort', '12/23/1978', 'True', '(835) 6051605', 'lforth@infoseek.co.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (19, 'Peria', 'Wrennie', 'Titterton', '11/06/1994', 'False', '(525) 6632180', 'wtittertoni@springer.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (20, 'Roderic', 'Herculie', 'Hutchence', '10/20/1991', 'True', '(668) 1778874', 'hhutchencej@cyberchimps.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (21, 'Liesa', 'Domini', 'Godber', '12/09/1985', 'False', '(212) 7455390', 'dgodberk@meetup.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (22, 'Fulton', 'Shell', 'Mulvany', '05/05/1966', 'True', '(204) 3509574', 'smulvanyl@arstechnica.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (23, 'Giuditta', 'Ted', 'State', '07/23/1982', 'False', '(720) 6525421', 'tstatem@hao123.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (24, 'Papageno', 'Valdemar', 'Winckle', '09/21/1966', 'True', '(959) 6359269', 'vwincklen@over-blog.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (25, 'Mattheus', 'Vincents', 'Hoggin', '09/15/1979', 'True', '(373) 9284647', 'vhoggino@state.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (26, 'Ryan', 'Dionysus', 'Weavers', '07/05/1964', 'True', '(976) 8276683', 'dweaversp@sfgate.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (27, 'Maxie', 'Hymie', 'Ferron', '06/07/1977', 'True', '(255) 7506264', 'hferronq@people.com.cn');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (28, 'Kenny', 'Arie', 'Crann', '07/25/1962', 'True', '(439) 9610284', 'acrannr@51.la');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (29, 'Gerry', 'Rafferty', 'Schutter', '07/01/1980', 'True', '(873) 4775128', 'rschutters@uiuc.edu');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (30, 'Netta', 'Willabella', 'Ferrucci', '05/01/1995', 'False', '(497) 9949987', 'wferruccit@berkeley.edu');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (31, 'Maddy', 'Leisha', 'Ruddick', '02/01/1966', 'False', '(616) 8012791', 'lruddicku@noaa.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (32, 'Michele', 'Tybi', 'Cerman', '05/09/1976', 'False', '(160) 1064196', 'tcermanv@jiathis.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (33, 'Natalina', 'Trisha', 'Sweetmore', '12/16/1978', 'False', '(601) 3957267', 'tsweetmorew@patch.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (34, 'Tiffanie', 'Joane', 'Pigeon', '01/01/1979', 'False', '(929) 6662814', 'jpigeonx@nymag.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (35, 'Saleem', 'Amerigo', 'Jurisic', '06/18/1969', 'True', '(574) 6897315', 'ajurisicy@archive.org');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (36, 'Rodrigo', 'Sollie', 'Markushkin', '06/12/1972', 'True', '(528) 2231003', 'smarkushkinz@prweb.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (37, 'Lelia', 'Corrie', 'Snalum', '05/25/1971', 'False', '(871) 8562462', 'csnalum10@nymag.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (38, 'Renado', 'Jonathon', 'Cettell', '08/24/1979', 'True', '(346) 1752769', 'jcettell11@discuz.net');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (39, 'Leo', 'Minda', 'Olenichev', '07/30/1960', 'False', '(753) 6117114', 'molenichev12@answers.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (40, 'Lamar', 'Ethan', 'Gillbanks', '09/21/1971', 'True', '(134) 7196697', 'egillbanks13@freewebs.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (41, 'Ronica', 'Thelma', 'Kagan', '04/25/1984', 'False', '(125) 5951475', 'tkagan14@ftc.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (42, 'Hyacinthe', 'Wynny', 'Terlinden', '04/28/1982', 'False', '(327) 8532532', 'wterlinden15@4shared.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (43, 'Yetty', 'Noami', 'Coldham', '12/11/1960', 'False', '(262) 1576201', 'ncoldham16@sourceforge.net');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (44, 'Eziechiele', 'Paige', 'Gates', '07/09/1989', 'True', '(708) 4423243', 'pgates17@amazon.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (45, 'Ibbie', 'Arlinda', 'Vedekhin', '03/17/1962', 'False', '(568) 5721338', 'avedekhin18@phpbb.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (46, 'Brett', 'Adriana', 'Karlmann', '09/07/1970', 'False', '(685) 9825302', 'akarlmann19@examiner.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (47, 'Hiram', 'Sayers', 'Howden', '05/22/1993', 'False', '(148) 7149092', 'showden1a@economist.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (48, 'Matias', 'Skye', 'Schimpke', '01/29/1966', 'True', '(215) 4658728', 'sschimpke1b@geocities.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (49, 'Helga', 'Meagan', 'Zanolli', '09/21/1976', 'False', '(992) 2882493', 'mzanolli1c@blinklist.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (50, 'Sutton', 'Reamonn', 'Pollastrino', '10/02/1980', 'True', '(220) 1049089', 'rpollastrino1d@geocities.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (51, 'Blanca', 'Nerissa', 'Chadband', '11/20/1989', 'False', '(992) 9762638', 'nchadband1e@webmd.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (52, 'Bernard', 'Nelson', 'Carruthers', '07/04/1981', 'True', '(427) 4501048', 'ncarruthers1f@forbes.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (53, 'Issy', 'Kay', 'Giddy', '03/05/1966', 'False', '(393) 9079087', 'kgiddy1g@alibaba.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (54, 'Dacy', 'Jenelle', 'Puckinghorne', '10/12/1982', 'False', '(527) 6528045', 'jpuckinghorne1h@senate.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (55, 'Ariel', 'Buck', 'Capin', '10/17/1975', 'True', '(743) 4093859', 'bcapin1i@drupal.org');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (56, 'Franklin', 'Matthiew', 'Redit', '04/26/1971', 'True', '(469) 5717883', 'mredit1j@state.tx.us');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (57, 'Goldi', 'Farand', 'Mouan', '09/04/1983', 'False', '(830) 7846256', 'fmouan1k@wix.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (58, 'Terri-jo', 'Joelie', 'Leblanc', '08/18/1974', 'False', '(614) 8135619', 'jleblanc1l@youtu.be');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (59, 'Sibel', 'Nelly', 'Curtoys', '04/12/1991', 'False', '(894) 1871458', 'ncurtoys1m@topsy.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (60, 'Sheree', 'Lisbeth', 'Mycroft', '07/24/1960', 'False', '(914) 4660448', 'lmycroft1n@webnode.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (61, 'Lissie', 'Moria', 'Byatt', '11/23/1990', 'False', '(997) 7411626', 'mbyatt1o@php.net');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (62, 'Louis', 'Giselbert', 'Wagner', '04/18/1976', 'True', '(553) 9956197', 'gwagner1p@epa.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (63, 'Dorry', 'Annamaria', 'Detoc', '06/02/1971', 'False', '(294) 6922559', 'adetoc1q@netvibes.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (64, 'Natalie', 'Jacquette', 'Tarte', '10/16/1985', 'False', '(656) 1541706', 'jtarte1r@bloomberg.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (65, 'Peggi', 'Sadella', 'Nockles', '01/26/1974', 'False', '(650) 1227615', 'snockles1s@51.la');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (66, 'Abbey', 'Nancee', 'Larose', '06/02/1966', 'False', '(990) 7510361', 'nlarose1t@blogspot.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (67, 'Marika', 'Jenine', 'Jimenez', '10/03/1992', 'False', '(860) 1201432', 'jjimenez1u@usa.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (68, 'Morton', 'Ewell', 'Beet', '02/09/1975', 'True', '(218) 2405302', 'ebeet1v@ocn.ne.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (69, 'Jason', 'Pattin', 'Dallimore', '01/08/1988', 'True', '(179) 2841076', 'pdallimore1w@bizjournals.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (70, 'Sheelagh', 'Phyllida', 'Melloi', '01/11/1968', 'False', '(697) 6643686', 'pmelloi1x@jigsy.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (71, 'Olenolin', 'Edward', 'Grunwald', '05/26/1968', 'True', '(955) 1256783', 'egrunwald1y@constantcontact.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (72, 'Fitzgerald', 'Judd', 'Kolak', '04/15/1982', 'True', '(605) 1967012', 'jkolak1z@upenn.edu');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (73, 'Frieda', 'Tera', 'Chippindale', '09/09/1963', 'False', '(393) 9500006', 'tchippindale20@huffingtonpost.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (74, 'Job', 'Frazier', 'Redmire', '09/09/1965', 'False', '(718) 8393726', 'fredmire21@businessweek.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (75, 'Jacob', 'Carson', 'Abdie', '11/25/1973', 'True', '(459) 5983173', 'cabdie22@plala.or.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (76, 'Lester', 'Lucais', 'Humphris', '01/29/1976', 'True', '(117) 8776647', 'lhumphris23@google.de');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (77, 'Patrick', 'Elbert', 'Haddleton', '05/30/1970', 'True', '(428) 4745494', 'ehaddleton24@state.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (78, 'Celesta', 'Anabella', 'Orrick', '09/06/1980', 'False', '(375) 9442572', 'aorrick25@seattletimes.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (79, 'Cam', 'Gay', 'Soppit', '11/06/1977', 'True', '(632) 5552608', 'gsoppit26@blinklist.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (80, 'Onofredo', 'Torrey', 'Crean', '07/20/1988', 'True', '(170) 5492330', 'tcrean27@comcast.net');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (81, 'Colin', 'Carly', 'Oliff', '08/11/1966', 'True', '(414) 3706393', 'coliff28@nifty.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (82, 'Jenda', 'Adoree', 'Gregory', '02/28/1984', 'False', '(415) 6085011', 'agregory29@t-online.de');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (83, 'Ralina', 'Leshia', 'Layfield', '08/23/1987', 'False', '(820) 5370197', 'llayfield2a@timesonline.co.uk');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (84, 'King', 'Bette', 'Haversum', '09/04/1977', 'False', '(859) 8810620', 'bhaversum2b@yelp.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (85, 'Kerwinn', 'Iggie', 'Salzberg', '12/31/1994', 'True', '(206) 4472207', 'isalzberg2c@webeden.co.uk');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (86, 'Dorthy', 'Anet', 'MacKall', '11/27/1980', 'False', '(625) 9624758', 'amackall2d@tiny.cc');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (87, 'Leeann', 'Maryjane', 'Hayworth', '10/27/1989', 'False', '(236) 5459232', 'mhayworth2e@amazon.co.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (88, 'Manolo', 'Claudelle', 'Jeal', '02/02/1973', 'False', '(775) 9760984', 'cjeal2f@weebly.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (89, 'Kalie', 'Aretha', 'Quayle', '02/14/1964', 'False', '(357) 4782448', 'aquayle2g@ed.gov');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (90, 'Jecho', 'Sinclair', 'Bettam', '01/30/1985', 'True', '(301) 6537932', 'sbettam2h@so-net.ne.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (91, 'Laurence', 'Leyla', 'Croom', '03/14/1979', 'False', '(596) 4103293', 'lcroom2i@google.co.uk');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (92, 'Gregoire', 'Stanislas', 'Aplin', '10/11/1992', 'True', '(485) 2706472', 'saplin2j@amazon.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (93, 'Delores', 'Mirilla', 'Longstreeth', '12/05/1974', 'False', '(128) 5071162', 'mlongstreeth2k@vk.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (94, 'Cherye', 'Laney', 'Coulling', '04/20/1978', 'False', '(888) 5052341', 'lcoulling2l@unblog.fr');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (95, 'Harbert', 'Benjamin', 'Reinmar', '10/13/1966', 'True', '(723) 5616398', 'breinmar2m@wikia.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (96, 'Land', 'Buddie', 'Crookes', '01/30/1990', 'True', '(133) 2474022', 'bcrookes2n@cnn.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (97, 'Cad', 'Dagny', 'Pembery', '10/06/1987', 'True', '(884) 9961957', 'dpembery2o@go.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (98, 'Mickie', 'Kipper', 'Rayne', '02/15/1962', 'True', '(666) 9039462', 'krayne2p@statcounter.com');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (99, 'Abram', 'Ariel', 'Braxton', '04/25/1992', 'True', '(464) 1875040', 'abraxton2q@amazon.co.jp');
insert into Customer (CustomerId, FirstName, MiddleName, LastName, DateOfBirth, Gender, PhoneNumber, Email) values (100, 'Clemence', 'Catriona', 'Pawlyn', '05/03/1989', 'False', '(634) 9397031', 'cpawlyn2r@dmoz.org');
GO