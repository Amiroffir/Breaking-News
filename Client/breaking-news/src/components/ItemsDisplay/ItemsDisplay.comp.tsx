import { Article } from "../../interfaces/Article.interface";
import { updatePopularityInDB } from "../../services/articles.service";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import "./items-display.scss";
import "../../flex.scss";

var settings = {
  dots: true,
  infinite: true,
  speed: 500,
  slidesToShow: 1,
  slidesToScroll: 1,
};

interface ItemsDisplayProps {
  articlesList: Article[] | null;
}

export const ItemsDisplay = (articlesList: ItemsDisplayProps) => {
  console.log("articlesList", articlesList.articlesList);

  const setPopularity = (id: number): void => {
    updatePopularityInDB(id);
  };

  return (
    <div className="items-topic-group flex">
      {articlesList.articlesList?.map((article: Article) => (
        <div className="item card" key={article.id}>
          <div className="item-title card-title">{article.headline}</div>
          <div className="item-content">{article.description}</div>
          <div className="item-img">
            <img src={article.imgUrl} alt="img" />
          </div>
          <div className="item-link">
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
