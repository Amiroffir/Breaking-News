select * from topics


--CREATE TABLE "TopicsIndex"(
--    "id" INT NOT NULL identity,
--    "topicName" NVARCHAR(255) NOT NULL,
--    )

    --ALTER TABLE TopicsIndex 
    --ADD Constraint  "topicsindex_id_primary" PRIMARY KEY("id");

    --ALTER TABLE topics 
    --ADD Constraint  "topics_topicindex_foreign" FOREIGN KEY("topicIndex") REFERENCES "TopicsIndex"("id");


    --Insert into TopicsIndex (topicName) values ('Law')

    --update Topics set topicIndex = 2 where topicName = 'Parenthood'
    --update Topics set topicIndex = 3 where topicName = 'Real Estate'
    --update Topics set topicIndex = 4 where topicName = 'Cars'
    --update Topics set topicIndex = 5 where topicName = 'Music'
    --update Topics set topicIndex = 6 where topicName = 'Health'
    --update Topics set topicIndex = 7 where topicName = 'Celebs'
    --update Topics set topicIndex = 8 where topicName = 'Judaism'
    --update Topics set topicIndex = 9 where topicName = 'Capital Markets'
    --update Topics set topicIndex = 10 where topicName = 'Enviroment'
    -- update Topics set topicIndex = 11 where topicName = 'Food'
    --  update Topics set topicIndex = 12 where topicName = 'Technology'
    --  update Topics set topicIndex = 13 where topicName = 'Weather'
    --  update Topics set topicIndex = 14 where topicName = 'Law'



    select * from TopicsIndex
    select * from topics