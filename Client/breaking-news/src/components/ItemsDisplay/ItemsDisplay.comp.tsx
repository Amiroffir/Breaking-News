import { log } from "console";
import React from "react";
import { Article } from "../../interfaces/Article.interface";
import { updatePopularityInDB } from "../../services/articles.service";
import "./items-display.scss";

interface ItemsDisplayProps {
  articlesList: Article[] | null;
}

export const ItemsDisplay = (articlesList: ItemsDisplayProps) => {
  console.log("articlesList", articlesList.articlesList);

  const setPopularity = (id: number): void => {
    updatePopularityInDB(id);
  };

  return (
    <div className="items-topic-group">
      {articlesList.articlesList?.map((article: Article) => (
        <div className="item card" key={article.id}>
          <div className="item__title card-title">{article.headline}</div>
          <div className="item__content">{article.description}</div>
          {/* <div className="item__img">
            <img src={article.imgUrl} alt="img" />
          </div> */}
          <div className="item__link">
            <a
              onClick={() => setPopularity(article.id)}
              href={article.link}
              target="_blank"
            >
              לכתבה המלאה
            </a>
          </div>
        </div>
      ))}
    </div>
  );
};
