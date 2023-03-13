CREATE TABLE "Favorites"(
    "id" INT NOT NULL,
    "articleID" INT NOT NULL,
    "TimesClicked" INT NOT NULL
);
ALTER TABLE
    "Favorites" ADD CONSTRAINT "favorites_id_primary" PRIMARY KEY("id");
CREATE TABLE "Articles"(
    "id" INT NOT NULL,
    "newsSource" INT NOT NULL,
    "image" NVARCHAR(500) NOT NULL,
    "headline" NVARCHAR(255) NOT NULL,
    "desc" NVARCHAR(255) NOT NULL,
    "link" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Articles" ADD CONSTRAINT "articles_id_primary" PRIMARY KEY("id");
CREATE TABLE "NewsSources"(
    "id" INT NOT NULL,
    "sourceName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "NewsSources" ADD CONSTRAINT "newssources_id_primary" PRIMARY KEY("id");
CREATE TABLE "Topics"(
    "id" INT NOT NULL,
    "newsSource" INT NOT NULL,
    "topicName" NVARCHAR(255) NOT NULL,
    "RSSLink" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Topics" ADD CONSTRAINT "topics_id_primary" PRIMARY KEY("id");
CREATE TABLE "Config"(
    "id" INT NOT NULL,
    "logPath" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Config" ADD CONSTRAINT "config_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "Topics" ADD CONSTRAINT "topics_newssource_foreign" FOREIGN KEY("newsSource") REFERENCES "NewsSources"("id");
ALTER TABLE
    "Articles" ADD CONSTRAINT "articles_newssource_foreign" FOREIGN KEY("newsSource") REFERENCES "NewsSources"("id");
ALTER TABLE
    "Favorites" ADD CONSTRAINT "favorites_articleid_foreign" FOREIGN KEY("articleID") REFERENCES "Articles"("id");