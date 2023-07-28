import style from "./textPartHeader.module.scss"
import logo from "../../../../../pics/headerPic/logo.png"
import {HeaderMainButton} from "../../../../../index.ts";
export const TextPartHeader = () => {
    return (
        <div className={style.wrapper}>
            <img src={logo}></img>
            <h1 className={style.mainText}>Good <span>Food &emsp;Good</span> <br></br>Moments</h1>
            <p className={style.smallText}>Everyone should do what they do best in life.
                Here, for example, we make sushi. The best sushi, unforgettabletaste in every piece.</p>
            <HeaderMainButton/>
        </div>
    );
}
