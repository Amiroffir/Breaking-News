import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import { ItemsDisplay } from "../../components/compsIndex";
import { Article } from "../../interfaces/Article.interface";
import { Topic } from "../../interfaces/Topic.interface";
import { getTrendingNews } from "../../services/articles.service";
import { LocalSelectedTopics } from "../../shareStates/selectedTopics.state";

export const TrendingPage = () => {
  const selectedTopics: Topic[] = useRecoilValue(LocalSelectedTopics);
  const [trendingNews, setTrendingNews] = useState<Article[]>([]);

  useEffect(() => {
    getTrendingNews(selectedTopics).then((res) => {
      if (res) {
        setTrendingNews(res);
      } else {
        setTrendingNews([]);
      }
    });
  }, []);

  return <ItemsDisplay articlesList={trendingNews} />;
};
