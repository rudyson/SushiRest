import style from "./TopHeader.module.scss"
import {Menu, HeaderButtons} from "../../../../index.ts";
export const TopHeader = () => {
    return (
        <section className={style.wrapper}>
            <h1>SUSHIREST</h1>
            <Menu/>
            <HeaderButtons/>
        </section>
    );
}
