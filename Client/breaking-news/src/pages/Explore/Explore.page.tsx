import { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import { ItemsDisplay } from "../../components/compsIndex";
import { Article } from "../../interfaces/Article.interface";
import { Topic } from "../../interfaces/Topic.interface";
import { getExploreNews } from "../../services/articles.service";
import { LocalSelectedTopics } from "../../shareStates/selectedTopics.state";
import "./explore.scss";

export const ExplorePage = () => {
  const selectedTopics: Topic[] = useRecoilValue(LocalSelectedTopics);
  const [exploreNews, setExploreNews] = useState<Article[]>([]);

  useEffect(() => {
    getExploreNews(selectedTopics).then((res) => {
      if (res) {
        setExploreNews(res);
      } else {
        setExploreNews([]);
      }
    });
  }, []);
  return (
    <div className="explore">
      <ItemsDisplay articlesList={exploreNews} />
    </div>
  );
};
