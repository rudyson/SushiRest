import style from "./mainPicHeader.module.scss"
import MainPic from "../../../../../pics/headerPic/BannerPic.png"

export const MainPicHeader = () => {
    return (
        <img className={style.pic} src={MainPic}>
        </img>
    );
}
