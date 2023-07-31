import style from "./topPositionSlider.module.scss"
import {A11y, Navigation, Pagination} from "swiper/modules"
import {Swiper, SwiperSlide} from "swiper/react"

import 'swiper/scss';
import 'swiper/scss/navigation'
import 'swiper/scss/pagination'
import 'swiper/scss/effect-coverflow'

import {useEffect, useState} from "react";
import axios from "axios";
import {TopPosSlide} from "../../../../../index.ts";

export const TopPositionSlider = () => {
    const [items, setItems] = useState([1])
    const fetchTopPos = async () => {
        const res = await axios.get('https://64c523fec853c26efada8b82.mockapi.io/topPositions')
        setItems(res.data)
    }
    useEffect(() => {
        fetchTopPos()
    }, [])
    return (
        <div className={style.wrapper}>
            <Swiper className={style.wrapperSwiper}
                    modules={[Navigation, Pagination, A11y]}
                    spaceBetween={40}
                    slidesPerView={2}
                    loop={true}
                    pagination={{clickable: true, }}
                    scrollbar={{draggable: true}}
            >
                {items.map((obj) => (
                    <SwiperSlide key={obj.id} className={style.el}>
                        <TopPosSlide key={obj.id} {...obj}/>
                    </SwiperSlide>
                ))}
            </Swiper>
        </div>
    )
}
