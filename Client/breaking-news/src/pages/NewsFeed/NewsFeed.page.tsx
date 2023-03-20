import { Key, useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import { ItemsDisplay } from "../../components/compsIndex";
import { Article } from "../../interfaces/Article.interface";
import { LocalSelectedTopics } from "../../shareStates/selectedTopics.state";
import { getSelectedTopicsItems } from "../../services/topics.service";
import { Topic } from "../../interfaces/Topic.interface";
import "./news-feed.scss";

export const NewsFeedPage = () => {
  const selectedTopics: Topic[] = useRecoilValue(LocalSelectedTopics);
  const [newsItemsByTopics, setNewsItemsByTopics] = useState<Article[][]>([]);

  const getSelectedTopics = async (): Promise<Article[][]> => {
    const res: Article[] = await getSelectedTopicsItems(selectedTopics);
    const newsByItems = divideNewsItemsByTopics(res, selectedTopics);
    return newsByItems;
  };
  const divideNewsItemsByTopics = (
    newsItems: Article[],
    topics: Topic[]
  ): Article[][] => {
    let newsItemsByTopics: Article[][] = [];
    topics.forEach((topic) => {
      newsItemsByTopics.push(
        newsItems.filter((item) => item.topicID === topic.topicID)
      );
    });
    return newsItemsByTopics;
  };

  useEffect(() => {
    getSelectedTopics().then((res) => {
      setNewsItemsByTopics(res);
    });
  }, []);
  return (
    <div className="news-feed">
      {newsItemsByTopics.map((newsItemsTopic: Article[], index: Key) => (
        <ItemsDisplay key={index} articlesList={newsItemsTopic} />
      ))}
    </div>
  );
};
