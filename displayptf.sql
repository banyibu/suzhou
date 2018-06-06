/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 50721
 Source Host           : 127.0.0.1:3306
 Source Schema         : displayptf

 Target Server Type    : MySQL
 Target Server Version : 50721
 File Encoding         : 65001

 Date: 25/04/2018 21:04:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for company
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company`  (
  `CP_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '公司编号，字符串类型',
  `CP_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CP_address` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CP_tpnumber` int(24) NULL DEFAULT NULL COMMENT '公司电话号码',
  `CP_longitude` decimal(10, 7) NOT NULL COMMENT '经度',
  `CP_latitude` decimal(10, 7) NOT NULL COMMENT '纬度',
  `CP_joindate` date NULL DEFAULT NULL COMMENT '公司加入平台时间',
  PRIMARY KEY (`CP_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of company
-- ----------------------------
INSERT INTO `company` VALUES (1, '苏州协同智能制造创新中心', '江苏省苏州市吴中区吴中大道2888号', 68120482, 120.5528580, 31.2015870, '2018-03-11');
INSERT INTO `company` VALUES (2, '苏州联鑫模具有限公司', '苏州市吴中区横泾镇天鹅荡路2001号', 84653291, 120.5522100, 31.1883260, '2018-04-11');
INSERT INTO `company` VALUES (3, '苏州耀辉精密模具有限公司', '\r\n苏州市昆山市锦溪镇邵甸港路401号', 84632159, 121.1682300, 31.4691040, '2018-04-22');
INSERT INTO `company` VALUES (4, '苏州宝雅福隆电器科技有限公司', '苏州市吴中区北官渡路', 67423168, 120.6516650, 31.2524590, '2018-01-11');
INSERT INTO `company` VALUES (5, '苏州馨营兰电子科技有限公司', '苏州市吴江区吴变大道86号', 57298436, 120.6656920, 31.0852690, '2018-02-02');
INSERT INTO `company` VALUES (6, '苏州慧通汇创科技有限公司', '苏州市吴江区', 62468732, 120.5865720, 31.2166790, '2018-02-12');
INSERT INTO `company` VALUES (7, '苏州荣威模具有限公司', '苏州市吴中区苏蠡路65-6号', 81423696, 120.6124860, 31.2514070, '2018-02-26');
INSERT INTO `company` VALUES (8, '苏州立创精密模具科技有限公司', '苏州市吴中区兴东路18号', 69451287, 120.5511820, 31.1847590, '2017-12-11');
INSERT INTO `company` VALUES (9, '苏州智能制造设备有限公司', '苏州市吴中区', 57264834, 120.5900000, 31.2000000, '2017-11-02');

-- ----------------------------
-- Table structure for cp_eqp
-- ----------------------------
DROP TABLE IF EXISTS `cp_eqp`;
CREATE TABLE `cp_eqp`  (
  `CP_ID` int(11) NOT NULL COMMENT '公司编号',
  `EQP_ID` int(255) NOT NULL COMMENT '设备编号',
  `CE_number` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`CP_ID`, `EQP_ID`) USING BTREE,
  INDEX `CE_EQP_ID`(`EQP_ID`) USING BTREE,
  CONSTRAINT `CE_CP_ID` FOREIGN KEY (`CP_ID`) REFERENCES `company` (`CP_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `CE_EQP_ID` FOREIGN KEY (`EQP_ID`) REFERENCES `equipment` (`EQP_ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cp_eqp
-- ----------------------------
INSERT INTO `cp_eqp` VALUES (1, 1, NULL);
INSERT INTO `cp_eqp` VALUES (1, 4, NULL);
INSERT INTO `cp_eqp` VALUES (1, 5, NULL);
INSERT INTO `cp_eqp` VALUES (1, 11, 1);
INSERT INTO `cp_eqp` VALUES (1, 12, 1);
INSERT INTO `cp_eqp` VALUES (1, 13, 1);
INSERT INTO `cp_eqp` VALUES (1, 14, 1);
INSERT INTO `cp_eqp` VALUES (1, 15, NULL);
INSERT INTO `cp_eqp` VALUES (1, 16, NULL);
INSERT INTO `cp_eqp` VALUES (2, 3, 1);
INSERT INTO `cp_eqp` VALUES (2, 7, 1);
INSERT INTO `cp_eqp` VALUES (2, 9, 1);
INSERT INTO `cp_eqp` VALUES (3, 2, 1);
INSERT INTO `cp_eqp` VALUES (3, 10, 1);
INSERT INTO `cp_eqp` VALUES (4, 6, 1);
INSERT INTO `cp_eqp` VALUES (5, 8, 1);

-- ----------------------------
-- Table structure for eqp_md
-- ----------------------------
DROP TABLE IF EXISTS `eqp_md`;
CREATE TABLE `eqp_md`  (
  `EQP_ID` int(11) NOT NULL COMMENT '设备编号',
  `MD_ID` int(11) NOT NULL COMMENT '模具编号',
  `No_off` bit(1) NULL DEFAULT NULL COMMENT '开闭标记',
  `Spindle_Speed` double NULL DEFAULT NULL COMMENT '主轴转速',
  `Coordinate` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '坐标精度',
  `Alarm` bit(1) NULL DEFAULT NULL COMMENT '报警标记',
  `MD_Progress` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`EQP_ID`, `MD_ID`) USING BTREE,
  INDEX `ME_MD_ID`(`MD_ID`) USING BTREE,
  CONSTRAINT `ME_EQP_ID` FOREIGN KEY (`EQP_ID`) REFERENCES `equipment` (`EQP_ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `ME_MD_ID` FOREIGN KEY (`MD_ID`) REFERENCES `mould` (`MD_ID`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of eqp_md
-- ----------------------------
INSERT INTO `eqp_md` VALUES (1, 2, b'0', 1600, NULL, NULL, 100);
INSERT INTO `eqp_md` VALUES (2, 4, b'1', 1400, NULL, NULL, 60);
INSERT INTO `eqp_md` VALUES (3, 3, b'1', 1700, NULL, NULL, 40);
INSERT INTO `eqp_md` VALUES (4, 1, b'1', 1800, NULL, NULL, 80);
INSERT INTO `eqp_md` VALUES (5, 5, b'1', 1800, NULL, NULL, 90);

-- ----------------------------
-- Table structure for equipment
-- ----------------------------
DROP TABLE IF EXISTS `equipment`;
CREATE TABLE `equipment`  (
  `EQP_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '设备编号',
  `EQP_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `EQP_brand` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备品牌',
  `EQP_model` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备型号',
  `EQP_Dateofmf` date NULL DEFAULT NULL COMMENT '设备生产日期',
  `EQP_orgin` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备产地',
  `EQP_category` varchar(5) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备种类',
  `EQP_offon` bit(1) NULL DEFAULT NULL COMMENT '设备启停状态',
  `EQP_state` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备运行状态',
  `EQP_process` int(11) NULL DEFAULT NULL COMMENT '设备加工进度',
  `EQP_time` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备加工时间',
  PRIMARY KEY (`EQP_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of equipment
-- ----------------------------
INSERT INTO `equipment` VALUES (1, '智能切割机', '西门子', 'MP8-30', '2006-03-01', '德国', 'EDM', b'1', '待机中', 0, '');
INSERT INTO `equipment` VALUES (2, '精密火花机', '发那科', 'ZNC750', '2008-03-05', '中国', 'EDW', b'1', '运行中', 60, '1小时30分');
INSERT INTO `equipment` VALUES (3, '数控机床', '发那科', 'CG52', '2013-06-09', '广州', 'CNC', b'1', '暂停中', 80, '2小时40分');
INSERT INTO `equipment` VALUES (4, '慢走丝切割机', '沙迪克', 'VL400QS', '2018-04-06', '日本', 'EDM', b'1', '异常停止', 40, '45分');
INSERT INTO `equipment` VALUES (5, '火花机', '沙迪克', 'VL500QS', '2018-04-10', '日本', 'EDW', b'0', '', NULL, '');
INSERT INTO `equipment` VALUES (6, '快走丝线切割', '西门子', 'MP8-40', '2018-04-09', '德国', 'EDM', b'1', '运行中', 90, '3小时');
INSERT INTO `equipment` VALUES (7, '智能数控机床', '西门子', 'MMP-80', '2018-04-11', '德国', 'CNC', b'1', '运行中', 30, '30分');
INSERT INTO `equipment` VALUES (8, '智能数控机床', '沙迪克', 'VLS-600', '2018-04-13', '日本', 'CNC', b'1', '暂停中', 50, '1小时');
INSERT INTO `equipment` VALUES (9, '精密火花机', '发那科', 'ZNC650', '2018-03-10', '苏州', 'EDW', b'1', '异常停止', 70, '1小时20分');
INSERT INTO `equipment` VALUES (10, '数控机床', '西门子', 'MP6-40', '2018-04-04', '德国', 'CNC', b'1', '运行中', 10, '20分');
INSERT INTO `equipment` VALUES (11, '切割机', '沙迪克', 'AD30LSDK1', '2018-01-06', '日本', 'EDM', b'1', '运行中', 60, '2小时');
INSERT INTO `equipment` VALUES (12, '切割机', '沙迪克', 'AD30LSDK2', '2018-01-06', '日本', 'EDM', b'1', '运行中', 80, '2小时20分');
INSERT INTO `equipment` VALUES (13, '切割机', '沙迪克', 'AD30LSDK3', '2018-01-06', '日本', 'EDM', b'1', '运行中', 40, '1小时15分');
INSERT INTO `equipment` VALUES (14, '切割机', '沙迪克', 'AD30LSDK4', '2018-01-06', '日本', 'EDM', b'1', '待机中', NULL, '');
INSERT INTO `equipment` VALUES (15, '切割机', '沙迪克', 'AD30LSDK5', '2018-01-06', '日本', 'EDM', b'1', '待机中', NULL, '');
INSERT INTO `equipment` VALUES (16, '火花机', '沙迪克', 'ALN400Qs', '2018-01-06', '日本', 'EDW', b'0', '', NULL, '');

-- ----------------------------
-- Table structure for mould
-- ----------------------------
DROP TABLE IF EXISTS `mould`;
CREATE TABLE `mould`  (
  `MD_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '模具编号',
  `MD_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `MD_drawing_ID` int(11) NULL DEFAULT NULL COMMENT '模具图纸编号',
  `MD_program_ID` int(11) NULL DEFAULT NULL COMMENT '模具生产程序',
  `MDS_offtime` datetime(0) NULL DEFAULT NULL COMMENT '模具开模时间',
  `MDS_ontime` datetime(0) NULL DEFAULT NULL COMMENT '模具比模时间',
  `MDS_address` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MDS_prodt_sum` int(11) NULL DEFAULT NULL COMMENT '模具生产的产品数量',
  `MDS_mtifo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '模具维修信息',
  PRIMARY KEY (`MD_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of mould
-- ----------------------------
INSERT INTO `mould` VALUES (1, 'md1', 1, 1, '2018-04-04 00:00:00', '2018-04-07 00:00:00', '武汉', NULL, NULL);
INSERT INTO `mould` VALUES (2, 'md2', 1, 3, '2018-04-05 00:00:00', '2018-04-06 00:00:00', '苏州', NULL, NULL);
INSERT INTO `mould` VALUES (3, 'md3', 2, 4, '2018-04-09 00:00:00', '2018-04-14 00:00:00', '苏州', NULL, NULL);
INSERT INTO `mould` VALUES (4, 'md4', 4, 2, '2018-04-11 00:00:00', '2018-04-18 00:00:00', '杭州', NULL, NULL);
INSERT INTO `mould` VALUES (5, 'md5', 3, 2, '2018-04-07 00:00:00', '2018-04-12 00:00:00', '北京', NULL, NULL);
INSERT INTO `mould` VALUES (6, 'md6', 2, 4, '2018-04-14 00:00:00', '2018-04-16 00:00:00', '上海', NULL, NULL);

-- ----------------------------
-- Table structure for od_md
-- ----------------------------
DROP TABLE IF EXISTS `od_md`;
CREATE TABLE `od_md`  (
  `OD_ID` int(11) NOT NULL COMMENT '订单编号',
  `MD_ID` int(11) NOT NULL COMMENT '模具编号',
  `OM_number` int(11) NULL DEFAULT NULL COMMENT '模具数量',
  PRIMARY KEY (`OD_ID`, `MD_ID`) USING BTREE,
  INDEX `OM_MD_ID`(`MD_ID`) USING BTREE,
  CONSTRAINT `OM_MD_ID` FOREIGN KEY (`MD_ID`) REFERENCES `mould` (`MD_ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `OM_OD_ID` FOREIGN KEY (`OD_ID`) REFERENCES `orders` (`OD_ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of od_md
-- ----------------------------
INSERT INTO `od_md` VALUES (1, 2, NULL);
INSERT INTO `od_md` VALUES (1, 3, NULL);
INSERT INTO `od_md` VALUES (2, 4, NULL);
INSERT INTO `od_md` VALUES (3, 1, NULL);
INSERT INTO `od_md` VALUES (3, 5, NULL);

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders`  (
  `OD_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '订单编号',
  `Customer_ID` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户标记',
  `OD_compstaus` int(11) NULL DEFAULT NULL COMMENT '订单完成进度',
  `OD_value` decimal(10, 0) NULL DEFAULT NULL COMMENT '订单金额',
  `CP_ID` int(11) NOT NULL COMMENT '公司ID',
  `OD_date` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`OD_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of orders
-- ----------------------------
INSERT INTO `orders` VALUES (1, '某客户1', 70, 500001, 3, '2017-06-11 00:00:00');
INSERT INTO `orders` VALUES (2, '某客户2', 60, 500000000, 2, '2017-08-23 00:00:00');
INSERT INTO `orders` VALUES (3, '客户3', 20, 400, 2, '2017-10-06 00:00:00');
INSERT INTO `orders` VALUES (4, '客户4', 70, 600, 1, '2017-10-07 00:00:00');
INSERT INTO `orders` VALUES (5, '客户5', 40, 800, 4, '2017-06-30 00:00:00');
INSERT INTO `orders` VALUES (6, '客户6', 90, 1000, 5, '2017-11-03 00:00:00');
INSERT INTO `orders` VALUES (7, '客户7', 60, 1200, 8, '2017-12-24 00:00:00');
INSERT INTO `orders` VALUES (8, '客户8', 80, 1400, 6, '2018-02-16 00:00:00');
INSERT INTO `orders` VALUES (9, '客户9', 40, 1600, 1, '2018-03-01 00:00:00');
INSERT INTO `orders` VALUES (10, '客户10', 50, 1800, 3, '2018-03-06 00:00:00');
INSERT INTO `orders` VALUES (11, '客户11', 30, 2000, 1, '2018-04-11 00:00:00');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `User_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_email` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `User_pword` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `User_typer` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `User_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`User_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, '1122@qq.com', 'admin', 'admin', 'admin');

SET FOREIGN_KEY_CHECKS = 1;
