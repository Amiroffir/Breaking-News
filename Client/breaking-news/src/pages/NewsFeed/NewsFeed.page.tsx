import { Key, useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import { ItemsDisplay } from "../../components/compsIndex";
import { Article } from "../../interfaces/Article.interface";
import {
  LocalSelectedTopics,
  SelectedTopicsNames,
} from "../../shareStates/selectedTopics.state";
import { getSelectedTopicsItems } from "../../services/topics.service";
import { Topic } from "../../interfaces/Topic.interface";
import "./news-feed.scss";

export const NewsFeedPage = () => {
  const selectedTopics: Topic[] = useRecoilValue(LocalSelectedTopics);
  const selectedTopicsNames: string[] = useRecoilValue(SelectedTopicsNames);
  const [newsItemsByTopics, setNewsItemsByTopics] = useState<Article[][]>([]);

  const getSelectedTopics = async (): Promise<Article[][]> => {
    const res: Article[] | null = await getSelectedTopicsItems(selectedTopics);
    if (!res) return [];
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
        <div className="items-by-topic-with-hl">
          <h3 className="items-display-hl">
            {selectedTopicsNames[index as number]}
          </h3>
          <ItemsDisplay key={index} articlesList={newsItemsTopic} />
        </div>
      ))}
    </div>
  );
};
