import React from "react";
import { Article } from "../../interfaces/Article.interface";
import "./items-display.scss";

interface ItemsDisplayProps {
  articlesList: Article[] | null;
}

export const ItemsDisplay = (articlesList: ItemsDisplayProps) => {
  return (
    <>
      {articlesList.articlesList &&
        articlesList.articlesList.map((article) => (
          <div key={article.articleID} className="card">
            <div className="card-body">
              <h5 className="card-title">{article.articleTitle}</h5>
              <p className="card-text">{article.articleDescription}</p>
            </div>
          </div>
        ))}
    </>
  );
};
