--Insert into NewsSources (sourceName) values ('walla'), ('maariv'), ('ynet'), ('mako');
select * from Topics

-- Mako


Insert into Topics (newsSource, topicName, RSSLink) values
(4,'Football','https://rcs.mako.co.il/rss/Sports-football-world.xml'),
(4,'Parenthood','https://rcs.mako.co.il/rss/home-family-babies.xml'),
--(4,'Real Estate','https://www.maariv.co.il/Rss/RssFeedsNadlan'),
(4,'Cars','https://rcs.mako.co.il/rss/225ead847806a210VgnVCM2000002a0c10acRCRD.xml'),
(4,'Music','https://rcs.mako.co.il/rss/f6750a2610f26110VgnVCM1000005201000aRCRD.xml'),
(4,'Health','https://rcs.mako.co.il/rss/c827a3ef43336410VgnVCM2000002a0c10acRCRD.xml'),
(4,'Celebs','https://rcs.mako.co.il/rss/1974a359d166a210VgnVCM2000002a0c10acRCRD.xml'),
(4,'Law','https://rcs.mako.co.il/rss/news-law.xml'),
(4,'Judaism','https://rcs.mako.co.il/rss/spirituality-popular_culture.xml'),
(4,'Capital Markets','https://rcs.mako.co.il/rss/men-money.xml'),
(4,'Weather','https://rcs.mako.co.il/rss/news-weather.xml'),
(4,'Enviroment','https://rcs.mako.co.il/rss/a6066a16b298a210VgnVCM2000002a0c10acRCRD.xml'),
(4,'Food','https://rcs.mako.co.il/rss/c7250a2610f26110VgnVCM1000005201000aRCRD.xml'),
(4,'Technology','https://rcs.mako.co.il/rss/cd0c4e8fc83b8310VgnVCM2000002a0c10acRCRD.xml');



-- Ynet

Insert into Topics (newsSource, topicName, RSSLink) values
(3,'Football','http://www.ynet.co.il/Integration/StoryRss57.xml'),
(3,'Parenthood','http://www.ynet.co.il/Integration/StoryRss3052.xml'),
--(3,'Real Estate','https://www.maariv.co.il/Rss/RssFeedsNadlan'),
(3,'Cars','http://www.ynet.co.il/Integration/StoryRss550.xml'),
(3,'Music','http://www.ynet.co.il/Integration/StoryRss538.xml'),
(3,'Health','http://www.ynet.co.il/Integration/StoryRss1208.xml'),
--(3,'Celebs','https://rcs.mako.co.il/rss/1974a359d166a210VgnVCM2000002a0c10acRCRD.xml'),
--(3,'Law','https://rcs.mako.co.il/rss/news-law.xml'),
(3,'Judaism','http://www.ynet.co.il/Integration/StoryRss4403.xml'),
(3,'Capital Markets','http://www.ynet.co.il/Integration/StoryRss6.xml'),
--(3,'Weather','https://rcs.mako.co.il/rss/news-weather.xml'),
(3,'Enviroment','http://www.ynet.co.il/Integration/StoryRss4879.xml'),
(3,'Food','http://www.ynet.co.il/Integration/StoryRss975.xml'),
(3,'Technology','http://www.ynet.co.il/Integration/StoryRss545.xml');


-- Maariv

Insert into Topics (newsSource, topicName, RSSLink) values
(2,'Football','https://www.maariv.co.il/Rss/RssFeedsKadoregelOlami'),
(2,'Parenthood','https://www.maariv.co.il/Rss/RssFeedsNewParents'),
(2,'Real Estate','https://www.maariv.co.il/Rss/RssFeedsNadlan'),
(2,'Cars','https://www.maariv.co.il/Rss/RssFeedsRechev'),
(2,'Music','https://www.maariv.co.il/Rss/RssFeedsMozika'),
(2,'Health','https://www.maariv.co.il/Rss/RssFeedsBriotVeYeoz'),
(2,'Celebs','https://www.maariv.co.il/Rss/RssFeedsRechilot'),
(2,'Law','https://www.maariv.co.il/Rss/RssMishpat'),
(2,'Judaism','https://www.maariv.co.il/Rss/Rssjewishism'),
(2,'Capital Markets','https://www.maariv.co.il/Rss/RssInvestmentHouse'),
(2,'Weather','https://www.maariv.co.il/Rss/RssFeedsWeather'),
(2,'Enviroment','https://www.maariv.co.il/Rss/RssFeedsEnvironment'),
(2,'Food','https://www.maariv.co.il/Rss/RssFeedsOchel'),
(2,'Technology','https://www.maariv.co.il/Rss/RssFeedsTechnologeya');


-- Walla

Insert into Topics (newsSource, topicName, RSSLink) values
(1,'Football','https://rss.walla.co.il/feed/316'),
(1,'Parenthood','https://rss.walla.co.il/feed/594'),
(1,'Real Estate','https://rss.walla.co.il/feed/13111'),
(1,'Cars','https://rss.walla.co.il/feed/4705'),
(1,'Music','https://rss.walla.co.il/feed/272'),
(1,'Health','https://rss.walla.co.il/feed/578'),
(1,'Celebs','https://rss.walla.co.il/feed/3602'),
--(1,'Law','https://www.maariv.co.il/Rss/RssMishpat'),
(1,'Judaism','https://rss.walla.co.il/feed/12937'),
(1,'Capital Markets','https://rss.walla.co.il/feed/112'),
--(1,'Weather','https://www.maariv.co.il/Rss/RssFeedsWeather'),
(1,'Enviroment','https://rss.walla.co.il/feed/13110'),
(1,'Food','https://rss.walla.co.il/feed/905'),
(1,'Technology','https://rss.walla.co.il/feed/4000');